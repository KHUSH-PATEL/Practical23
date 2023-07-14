using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Practical23_Factory.BAL.FactoryMethod.AbstractFactories;
using Practical23_Factory.BAL.FactoryMethod.DepartmentManagers;
using Practical23_Factory.BAL.FactoryMethod.Factories;
using Practical23_Factory.Database.Entities;
using Practical23_Factory.Database.Repositories;
using Practical23_Factory.Dto;

namespace Practical23_Factory.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeesController(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository= employeeRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetStudentsAsync()
        {
            var employees = await _employeeRepository.GetEmployeesAsync();
            return Ok(_mapper.Map<IEnumerable<EmployeeDto>>(employees));
        }

        [HttpGet("{id:int}", Name = "GetEmployeeByIdAsync")]
        public async Task<ActionResult<EmployeeDto>> GetEmployeeByIdAsync(int id)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(id);
            if (employee is null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<EmployeeDto>(employee));
        }

        [HttpGet("{id:int}/hours/{hours:int}")]
        public async Task<ActionResult<EmployeeDtoWithHoursAndBouns>> GetBounsFromEmployeeId(int id, int hours)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(id);
            if (employee is null)
            {
                return NotFound();
            }
            IDepartmentManager? departmentManager = null;
            switch (employee.DepartmentId)
            {
                case Database.Entities.Department.IT:
                    departmentManager = new BAL.FactoryMethod.Factories.ITDepartmentFactory().CreateDepartmentManager();
                    break;
                case Database.Entities.Department.Admin:
                    departmentManager = new BAL.FactoryMethod.Factories.AdminDepartmentFactory().CreateDepartmentManager();
                    break;
                case Database.Entities.Department.HR:
                    departmentManager = new BAL.FactoryMethod.Factories.HRDepartmentFactory().CreateDepartmentManager();
                    break;
                case Database.Entities.Department.Sales:
                    departmentManager = new BAL.FactoryMethod.Factories.SalesDepartmentFactory().CreateDepartmentManager();
                    break;
                case Database.Entities.Department.OnSite:
                    departmentManager = new BAL.FactoryMethod.Factories.OnSIteDepartmentFactory().CreateDepartmentManager();
                    break;
                default:
                    break;
            }
            var employeeWithHoursAndBouns = _mapper.Map<EmployeeDtoWithHoursAndBouns>(employee);
            employeeWithHoursAndBouns.Hours = hours;
            if (departmentManager is not null)
            {
                employeeWithHoursAndBouns.Bouns = departmentManager.CalculateOverTime(hours);
            }
            return Ok(employeeWithHoursAndBouns);
        }

        [HttpGet("{id:int}/abstract/hours/{hours:int}")]
        public async Task<ActionResult<EmployeeDtoWithHoursAndBouns>> GetBounsFromEmployeeIdUsingAbstract(int id, int hours)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(id);
            if (employee is null)
            {
                return NotFound();
            }

            IndoorDepartmentFactory? indoorDepartmentFactory = null;
            OutdootDepartmentFactory? outdoorDepartmentFactory = null;
            IDepartmentManager? departmentManager = null;
            switch (employee.DepartmentId)
            {
                case Database.Entities.Department.IT:
                    indoorDepartmentFactory = new BAL.FactoryMethod.AbstractFactories.ITDepartmentFactory();
                    departmentManager = indoorDepartmentFactory.CreateDepartmentManager();
                    break;
                case Database.Entities.Department.Admin:
                    indoorDepartmentFactory = new BAL.FactoryMethod.AbstractFactories.AdminDepartmentFactory();
                    departmentManager = indoorDepartmentFactory.CreateDepartmentManager();
                    break;
                case Database.Entities.Department.HR:
                    indoorDepartmentFactory = new BAL.FactoryMethod.AbstractFactories.HRDepartmentFactory();
                    departmentManager = indoorDepartmentFactory.CreateDepartmentManager();
                    break;
                case Database.Entities.Department.Sales:
                    outdoorDepartmentFactory = new BAL.FactoryMethod.AbstractFactories.SalesDepartmentFactory();
                    departmentManager = outdoorDepartmentFactory.CreateDepartmentManager();
                    break;
                case Database.Entities.Department.OnSite:
                    outdoorDepartmentFactory = new BAL.FactoryMethod.AbstractFactories.OnSIteDepartmentFactory();
                    departmentManager = outdoorDepartmentFactory.CreateDepartmentManager();
                    break;
                default:
                    break;
            }
            var employeeWithHoursAndBouns = _mapper.Map<EmployeeDtoWithHoursAndBouns>(employee);
            employeeWithHoursAndBouns.Hours = hours;
            if (departmentManager is not null)
            {
                employeeWithHoursAndBouns.Bouns = departmentManager.CalculateOverTime(hours);
            }
            return Ok(employeeWithHoursAndBouns);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployeeAsync(CreateEmployeeDto createEmployee)
        {
            if (!ModelState.IsValid)
            {
                var errors = string.Join(", ", ModelState.Values.SelectMany(x => x.Errors.Select(c => c.ErrorMessage)).ToList());
                return UnprocessableEntity(ModelState);
            }
            var employeeToInsert = _mapper.Map<Employee>(createEmployee);
            await _employeeRepository.CreateEmployeeAsync(employeeToInsert);
            await _employeeRepository.SaveChangesAsync();
            var createdEmployeeToReturn = _mapper.Map<EmployeeDto>(employeeToInsert);

            return CreatedAtRoute("GetEmployeeByIdAsync", new { id = createdEmployeeToReturn.Id }, createdEmployeeToReturn);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<EmployeeDto>> UpdateEmployeeAsync(int id, UpdateEmployeeDto updateEmployee)
        {
            var employeeEntity = await _employeeRepository.GetEmployeeByIdAsync(id);
            if (employeeEntity is null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                var errors = string.Join(", ", ModelState.Values.SelectMany(x => x.Errors.Select(c => c.ErrorMessage)).ToList());
                return UnprocessableEntity(ModelState);
            }
            _mapper.Map(updateEmployee, employeeEntity);

            await _employeeRepository.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<EmployeeDto>> DeleteEmployeeAsync(int id)
        {
            var employeeEntity = await _employeeRepository.GetEmployeeByIdAsync(id);
            if (employeeEntity is null)
            {
                return NotFound();
            }
            await _employeeRepository.DeleteEmployeeAsync(employeeEntity);
            await _employeeRepository.SaveChangesAsync();
            return NoContent();
        }
    }
}

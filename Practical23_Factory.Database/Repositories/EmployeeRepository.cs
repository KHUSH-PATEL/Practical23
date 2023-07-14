using Microsoft.EntityFrameworkCore;
using Practical23_Factory.Database.Context;
using Practical23_Factory.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical23_Factory.Database.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;
        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task DeleteEmployeeAsync(Employee employee)
        {
            var employeeEntity = await GetEmployeeByIdAsync(employee.Id);
            if (employeeEntity != null)
            {
                employeeEntity.DeleteStatus = true;
                _context.Employees.Update(employeeEntity);
            }
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee?> GetEmployeeByIdAsync(int id)
        {
            return await _context.Employees.FirstOrDefaultAsync(emp => emp.Id == id);
        }

        public async Task CreateEmployeeAsync(Employee employee)
        {
           await _context.Employees.AddAsync(employee);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}

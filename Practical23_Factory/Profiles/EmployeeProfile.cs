using AutoMapper;
using Practical23_Factory.Database.Entities;
using Practical23_Factory.Dto;

namespace Practical23_Factory.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeeDto, Employee>();
            CreateMap<Employee, EmployeeDto>();

            CreateMap<CreateEmployeeDto, Employee>();
            CreateMap<Employee, CreateEmployeeDto>();

            CreateMap<UpdateEmployeeDto, Employee>();
            CreateMap<Employee, UpdateEmployeeDto>();

            CreateMap<Employee, EmployeeDtoWithHoursAndBouns>();
        }
    }
}

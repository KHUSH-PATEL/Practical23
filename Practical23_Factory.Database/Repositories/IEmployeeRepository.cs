using Practical23_Factory.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical23_Factory.Database.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployeesAsync();
        Task<Employee?> GetEmployeeByIdAsync(int id);
        public Task CreateEmployeeAsync(Employee employee);
        public Task DeleteEmployeeAsync(Employee employee);
        public Task<bool> SaveChangesAsync();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp.Core.Entities;

namespace MyApp.Core.Interfaces
{
    public interface IEmployeeRepository
    {
        public Task<IEnumerable<EmployeeEntity>> GetEmployees();

        public Task<EmployeeEntity> GetEmployeeById(Guid id);

        public Task<EmployeeEntity> AddEmployee(EmployeeEntity entity);

        public Task<EmployeeEntity> UpdateEmployee(Guid id, EmployeeEntity entity);

        public Task<bool> DeleteEmployee(Guid id);
    }
}

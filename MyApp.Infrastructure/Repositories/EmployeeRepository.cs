using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp.Core.Interfaces;
using MyApp.Infrastructure.Data;
using MyApp.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace MyApp.Infrastructure.Repositories
{
    public class EmployeeRepository(AppDbContext dbContext) : IEmployeeRepository
    {
        public async Task<IEnumerable<EmployeeEntity>> GetEmployees()
        {
            return await dbContext.Employees.ToListAsync();
        }

        public async Task<EmployeeEntity> GetEmployeeById(Guid id)
        {
            return await dbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<EmployeeEntity> AddEmployee(EmployeeEntity entity)
        {
            entity.Id = Guid.NewGuid();
            dbContext.Employees.Add(entity);

            await dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<EmployeeEntity> UpdateEmployee(Guid id, EmployeeEntity entity)
        {
            EmployeeEntity employee = await dbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);

            if (employee is not null)
            {
                employee.Name = entity.Name;
                employee.Email = entity.Email;
                employee.Phone = entity.Phone;
                await dbContext.SaveChangesAsync();

                return employee;
            }

            return entity;
        }

        public async Task<bool> DeleteEmployee(Guid id)
        {
            EmployeeEntity employee = await dbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);

            if (employee is not null)
            {
                dbContext.Employees.Remove(employee);

                // Greater than zero indicates sucessfull deletion
                return await dbContext.SaveChangesAsync() > 0;
            }

            return false;
        }
    }
}

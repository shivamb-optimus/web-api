using MediatR;
using MyApp.Core.Entities;
using MyApp.Core.Interfaces;

namespace MyApp.Application.Queries
{
    public record GetEmployeesById(Guid EmployeeId) : IRequest<EmployeeEntity>;

    public class GetEmployeesByIdHandler(IEmployeeRepository employeeRepository) : IRequestHandler<GetEmployeesById, EmployeeEntity>
    {
        public async Task<EmployeeEntity> Handle(GetEmployeesById request, CancellationToken cancellationToken)
        {
            return await employeeRepository.GetEmployeeById(request.EmployeeId);
        }
    }
}

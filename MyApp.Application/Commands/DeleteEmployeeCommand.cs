﻿using MediatR;
using MyApp.Core.Interfaces;

namespace MyApp.Application.Commands
{
    public record DeleteEmployeeCommand(Guid EmployeeId) : IRequest<bool>;

    public class DeleteEmployeeCommandHandler(IEmployeeRepository employeeRepository) : IRequestHandler<DeleteEmployeeCommand, bool>
    {
        public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            return await employeeRepository.DeleteEmployee(request.EmployeeId);
        }
    }
}

using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Commands;
using MyApp.Application.Queries;
using MyApp.Core.Entities;

namespace MyApp.Api.Controllers
{
    // Used to define base route for Employee controller (class level routing att)
    //[Route("api/[controller]")]

    [ApiController]

    // The name of the class will determine the value of controller in app routing
    public class EmployeesController(IMediator mediator) : ControllerBase
    {
        // Used to indicate an action for this type of POST request (method level routing att)
        [HttpPost("")]
        public async Task<IActionResult> AddEmployeeAsync([FromBody] EmployeeEntity employee)
        {
            var result = await mediator.Send(new AddEmployeeCommand(employee));
            return Ok(result);
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllEmployeesAsync()
        {
            var result = await mediator.Send(new GetAllEmployeesQuery());
            return Ok(result);
        }

        [HttpGet("{employeeId}")]
        public async Task<IActionResult> GetEmployeeByIdAsync([FromRoute] Guid employeeId)
        {
            var result = await mediator.Send(new GetEmployeesById(employeeId));
            return Ok(result);
        }

        [HttpPut("{employeeId}")]
        public async Task<IActionResult> UpdateEmployeeAsync([FromRoute] Guid employeeId, [FromBody] EmployeeEntity employee)
        {
            var result = await mediator.Send(new UpdateEmployeeCommand(employeeId, employee));
            return Ok(result);
        }

        [HttpDelete("{employeeId}")]
        public async Task<IActionResult> DeleteEmployeeAsync([FromRoute] Guid employeeId)
        {
            var result = await mediator.Send(new DeleteEmployeeCommand(employeeId));
            return Ok(result);
        }
    }
}

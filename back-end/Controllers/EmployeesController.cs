using EmployeeManagement.Commands;
using EmployeeManagement.Models;
using EmployeeManagement.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("AllowSpecificOrigin")]
    public class EmployeesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeesController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee([FromBody] CreateEmployeeCommand command)
        {
            var createdEmployee = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetEmployee), new { id = createdEmployee.Id }, createdEmployee);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(Guid id, [FromBody] UpdateEmployeeCommand command)
        {
            if (id != command.Id)
            {
            

                return BadRequest("The provided ID does not match the employee ID.");
            }

            var updatedEmployee = await _mediator.Send(command);
            return Ok(updatedEmployee);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployees()
        {
            var employees = await _mediator.Send(new GetAllEmployeesQuery());

            return Ok(employees);
        }

        [HttpDelete("{id}")]
      public async Task<IActionResult> DeleteEmployee(Guid id)
{
    var command = new DeleteEmployeeCommand { Id = id };
    var result = await _mediator.Send(command);

    if (!result)
    {
        return NotFound(); // Return 404 if the employee was not found
    }

    return Ok("employee deleted succesfully"); 
}


    [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(Guid id)
        {
            var query = new GetEmployeeByIdQuery { Id = id };
            var employee = await _mediator.Send(query);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }
    }
}

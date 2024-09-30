using App.core.Apps.Employee.Command;
using App.core.Apps.Employee.Query;
using App.core.Models;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeManagementController : ControllerBase
    {

        private readonly IMediator _mediator;

        public EmployeeManagementController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllEmployee()
        {
            var allEmployee = await _mediator.Send(new GetEmployeeQuery());
            return Ok(allEmployee);
        }


        [HttpGet("Get-All-Employee-By-DeparmentId/{id}")]
        public async Task<IActionResult> GetAllEmployeeByDeparmentId(int id)
        {
            var allEmployeeByDepartmentId = await _mediator.Send(new GetAllEmployeeByDeparmentId { Id = id });

            if (allEmployeeByDepartmentId == null || allEmployeeByDepartmentId.Count == 0)
            {
                return NotFound("Employee Not Found");
            }

            return Ok(allEmployeeByDepartmentId);
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var employee = await _mediator.Send(new GetEmployeeByIdQuery { Id = id });

            if (employee == null)
            {
                return NotFound("Employee Not Found");
            }


            return Ok(employee);
        }



        [HttpPost]
        public async Task<IActionResult> AddEmployee(EmployeeDto model)
        {
            var isEmployeeAdded = await _mediator.Send(new CreateEmployeeCommand { Employee = model });

            if (!isEmployeeAdded)
            {
                return NotFound("Department Not Found");
            }

            return Ok("Employee Added Successfully");
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployeeById(EmployeeDto model, int id)
        {
            var isUpdated = await _mediator.Send(new UpdateEmployeeByIdCommand { Employee = model, Id = id });

            if (!isUpdated)
            {
                return NotFound("Either Employee Or Department Not Found");
            }

            return Ok("Update Employee Successfully");
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeById(int id)
        {
            var isDeleted = await _mediator.Send(new DeleteEmployeeByIdCommand { Id = id });

            if (!isDeleted)
            {
                return NotFound("Employee Not Found");
            }

            return Ok("Employee Deleted Successfully");
        }



    }
}

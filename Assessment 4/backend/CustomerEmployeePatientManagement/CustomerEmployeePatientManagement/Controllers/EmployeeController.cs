using App.Core.Apps.Customer.Command;
using App.Core.Apps.Customer.Query;
using App.Core.Apps.Employee.Command;
using App.Core.Apps.Employee.Query;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerEmployeePatientManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {


        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> GetActiveEmployee()
        {
            var allEmployee = await _mediator.Send(new GetActiveEmployeeQuery());
            return Ok(allEmployee);
        }

        [HttpGet("allEmployee")]
        public async Task<IActionResult> GetAllEmployee()
        {
            var allEmployee = await _mediator.Send(new GetAllEmployeeQuery());
            return Ok(allEmployee);
        }



        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetCustomerById(int id)
        //{
        //    var customer = await _mediator.Send(new GetCustomerByIdQuery { Id = id });

        //    if (customer == null)
        //    {
        //        return NotFound("Customer Not Found");
        //    }


        //    return Ok(customer);
        //}



        [HttpPost]
        public async Task<IActionResult> AddCustomer(Employee model)
        {
            var isEmployeeAdded = await _mediator.Send(new CreateEmployeeCommand { Employee = model });

            if (!isEmployeeAdded)
            {
                return NotFound(new { message = "Employee Not Added" });
            }

            return Ok(new { message = "Employee Added Successfully" });
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployeeById(Employee model, int id)
        {
            var isUpdated = await _mediator.Send(new UpdateEmployeeCommand { Employee = model, Id = id });

            if (!isUpdated)
            {
                return NotFound(new { message = "Employee Not Found" });
            }

            return Ok(new { message = "Update Employee Successfully" });
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeById(int id)
        {
            var isDeleted = await _mediator.Send(new DeleteEmployeePermanentCommand { Id = id });

            if (!isDeleted)
            {
                return NotFound(new { message = "Employee Not Found" });
            }

            return Ok(new { message = "Employee Deleted Successfully" });
        }




    }
}

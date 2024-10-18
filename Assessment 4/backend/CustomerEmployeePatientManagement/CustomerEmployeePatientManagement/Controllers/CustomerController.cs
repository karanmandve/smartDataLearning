using App.Core.Apps.Customer.Command;
using App.Core.Apps.Customer.Query;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerEmployeePatientManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {


        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllCustomer()
        {
            var allCustomer = await _mediator.Send(new GetCustomerQuery());
            return Ok(allCustomer);
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
        public async Task<IActionResult> AddCustomer(Customer model)
        {
            var isCustomerAdded = await _mediator.Send(new CreateCustomerCommand { Customer = model });

            if (!isCustomerAdded)
            {
                return NotFound(new { message = "Customer Not Added" });
            }

            return Ok(new { message = "Customer Added Successfully" });
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomerById(Customer model, int id)
        {
            var isUpdated = await _mediator.Send(new UpdateCustomerByIdCommand { Customer = model, Id = id });

            if (!isUpdated)
            {
                return NotFound(new { message = "Customer Not Found" });
            }

            return Ok(new { message = "Update Customer Successfully" });
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerById(int id)
        {
            var isDeleted = await _mediator.Send(new DeleteCustomerByIdCommand { Id = id });

            if (!isDeleted)
            {
                return NotFound(new { message = "Customer Not Found" });
            }

            return Ok(new { message = "Customer Deleted Successfully" });
        }


    }
}

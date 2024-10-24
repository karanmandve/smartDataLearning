using App.Core.Apps.User.Command;
using App.Core.Apps.User.Query;
using Domain;
using Domain.ModelDto;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RegisterLoginForget.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {


        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }


        //[HttpGet]
        //public async Task<IActionResult> GetActiveCustomer()
        //{
        //    var allCustomer = await _mediator.Send(new GetActiveCustomerQuery());
        //    return Ok(allCustomer);
        //}

        //[HttpGet("allCustomer")]
        //public async Task<IActionResult> GetAllCustomer()
        //{
        //    var allCustomer = await _mediator.Send(new GetAllCustomer());
        //    return Ok(allCustomer);
        //}



        [HttpGet("get-user-by-email/{email}")]
        public async Task<IActionResult> GetCustomerById(string email)
        {
            var user = await _mediator.Send(new GetUserByEmailQuery { Email = email });

            if (user == null)
            {
                return NotFound(new
                {
                    message = "User Not Found",
                    statusCode = 404
                });
            }


            return Ok(user);
        }



        [HttpPost]
        public async Task<IActionResult> RegisterUser(User model)
        {
            var isUserAdded = await _mediator.Send(new CreateUserCommand { User = model });

            if (!isUserAdded)
            {
                return Conflict(new
                {
                    statusCode = 409,
                    message = "User Already Exist"
                });
            }

            return Ok(new
            {
                statusCode = 200,
                message = "User Added Successfully"
            });
        }


        [HttpPost("/login-user")]
        public async Task<IActionResult> LoginUser(LoginDto model)
        {
            var isUserValidate = await _mediator.Send(new ValidateUserQuery { Login = model });

            if (!isUserValidate)
            {
                return Unauthorized(new
                {
                    statusCode = 401,
                    message = "Invalid Credentials"
                });
            }

            return Ok(new
            {
                statusCode = 200,
                message = "Login Successfull"
            });
        }


        [HttpPost("/change-password")]
        public async Task<IActionResult> ChangePassword(ChangeUserPasswordDto model)
        {
            var isPasswordChange = await _mediator.Send(new ChangeUserPasswordCommand { UserPasswordDto = model });

            if (!isPasswordChange)
            {
                return BadRequest(new
                {
                    statusCode = 400,
                    message = "Invalid Credentials or Current Password Incorrect"
                });
            }

            return Ok(new
            {
                statusCode = 200,
                message = "Password Change Successfully"
            });
        }


        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateCustomerById(Customer model, int id)
        //{
        //    var response = await _mediator.Send(new UpdateCustomerByIdCommand { Customer = model, Id = id });

        //    //if (!isUpdated)
        //    //{
        //    //    return NotFound(new { message = "Customer Not Found" });
        //    //}
        //    return Ok(response);
        //    //return Ok(new { message = "Update Customer Successfully" });
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteCustomerById(int id)
        //{
        //    var isDeleted = await _mediator.Send(new DeleteCustomerByIdPermanentCommand { Id = id });

        //    if (!isDeleted)
        //    {
        //        return NotFound(new { message = "Customer Not Found" });
        //    }

        //    return Ok(new { message = "Customer Deleted Successfully" });
        //}




    }
}

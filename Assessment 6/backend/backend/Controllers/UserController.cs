using core.App.User.Command;
using core.App.User.Query;
using domain.ModelDto;
using domain.ModelValidators;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
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

        [HttpGet("getUserByEmail/{email}")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            var result = await _mediator.Send(new core.App.User.Query.GetUserByEmailQuery { Email = email });
            if (result == null)
            {
                return NotFound(new
                {
                    statusCode = 404,
                    message = "User Not Found"
                });
            }
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await _mediator.Send(new GetAllUsersQuery());
            if (result == null)
            {
                return NotFound(new
                {
                    statusCode = 404,
                    message = "User Not Found"
                });
            }
            return Ok(result);
        }


        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(domain.ModelDto.RegisterDto model)
        {
            var validator = new RegisterDtoValidator();
            var isModeltValid = validator.Validate(model);

            if (!isModeltValid.IsValid)
            {
                var errorMessage = isModeltValid.Errors[0].ErrorMessage;
                return BadRequest(new { Errors = isModeltValid.Errors.Select(x => x.ErrorMessage).ToList() });
            }



            var result = await _mediator.Send(new core.App.User.Command.CreateUserCommand { RegisterUser = model });
            if (!result)
            {
                return Conflict(new
                {
                    statusCode = 409,
                    message = "Email already exist"
                });
            }
            return Ok(new
            {
                statusCode = 200,
                message = "User Created Successfully"
            });
        }

        [HttpPost("Auth/Authenticate")]
        public async Task<IActionResult> LoginUser(LoginDto model)
        {
            var validator = new LoginDtoValidator();
            var isModeltValid = validator.Validate(model);

            if (!isModeltValid.IsValid)
            {
                var errorMessage = isModeltValid.Errors[0].ErrorMessage;
                return BadRequest(new { Errors = isModeltValid.Errors.Select(x => x.ErrorMessage).ToList() });
            }


            var result = await _mediator.Send(new UserLoginQuery { LoginUser = model });
            if (result is string)
            {
                return Unauthorized(new
                {
                    statusCode = 401,
                    message = result
                });
            }

            return Ok(new
            {
                statusCode = 200,
                message = "Login Successfull",
                data = result
            });
        }

        [HttpGet("sendotp/{email}")]
        public async Task<IActionResult> SendOtp(string email)
        {
            var result = await _mediator.Send(new SendOtpCommand { Email = email });
            if (result is string)
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
                message = "Otp Send Successfully",
                data = result
            });
        }

    }
}

using FluentValidation;
using LogValidationExceptionExample.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LogValidationExceptionExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {

        private readonly ILogger<StudentsController> _logger;

        public StudentsController(ILogger<StudentsController> logger)
        {
            _logger = logger;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> ExceptionTest()
        {
            var test = await Task.FromResult(0);

            throw new Exception("Test");

            return Ok();
        }

        //[action] take method name
        [HttpPost("[action]")]
        public async Task<IActionResult> ValidationTest(TestModelDto model, IValidator<TestModelDto> validator)
        {
            var test = await Task.FromResult(0);
            var result = validator.Validate(model);

            if (!result.IsValid)
            {
                var errorMessage = result.Errors[0].ErrorMessage;
                _logger.LogError(errorMessage);
                return BadRequest(errorMessage);
            }

            return Ok();
        }


    }
}

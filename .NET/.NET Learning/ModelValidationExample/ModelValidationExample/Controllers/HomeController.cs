using Microsoft.AspNetCore.Mvc;
using ModelValidationExample.Models;

namespace ModelValidationExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("register")]
        public IActionResult Index(PersonDto person)
        {

            if (!ModelState.IsValid)
            {
                var errors = string.Join("\n", ModelState.Values.SelectMany(values => values.Errors).Select(err => err.ErrorMessage).ToList());

                //var errors = string.Join("\n", errorList);
                return BadRequest(errors);
            }

            return Ok($"{person}");

        }
    }
}

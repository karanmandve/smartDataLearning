using Microsoft.AspNetCore.Mvc;
using ModelValidationExample.CustomModelBinders;
using ModelValidationExample.Models;

namespace ModelValidationExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("register")]
        //[Bind(nameof(PersonDto.PersonName), nameof(PersonDto.Email), nameof(PersonDto.Password), nameof(PersonDto.ConfirmPassword))]
        //public IActionResult Index([FromBody][ModelBinder(BinderType = typeof(PersonModelBinder))] PersonDto person)
        //{

        //    if (!ModelState.IsValid)
        //    {
        //        var errors = string.Join("\n", ModelState.Values.SelectMany(values => values.Errors).Select(err => err.ErrorMessage).ToList());

        //        //var errors = string.Join("\n", errorList);
        //        return BadRequest(errors);
        //    }

        //    return Ok($"{person}");

        //}


        public IActionResult Index(PersonDto person, [FromHeader(Name = "User-Agent")] string userAgent)
        {

            if (!ModelState.IsValid)
            {
                var errors = string.Join("\n", ModelState.Values.SelectMany(values => values.Errors).Select(err => err.ErrorMessage).ToList());

                //var errors = string.Join("\n", errorList);
                return BadRequest(errors);
            }

            return Ok($"{person} user agent is : {userAgent}");

        }






    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TrainningSessionExamples.Controllers
{
    [Authorize]


    public class UserController : Controller
    {
        private readonly IJWTManagerRepository _jWTManager;
        public UserController(IJWTManagerRepository jWTManager)
        {
            this._jWTManager = jWTManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate(Login usersdata)
        {
            var token = _jWTManager.Authenticate(usersdata);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("GetUser")]
        public List<string> Get()
        {
            var users = new List<string>
        {
            "Satinder Singh",
            "Amit Sarna",
            "Davin Jon"
        };
            return users;
        }
    }
}

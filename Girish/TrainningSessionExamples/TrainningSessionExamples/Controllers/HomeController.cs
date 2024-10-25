using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using TrainningSessionExamples.Models;

namespace TrainningSessionExamples.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;



        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        //[AllowAnonymous]
        //[HttpPost("login")]
        //public IActionResult Login([FromBody] Login user)
        //{
        //    if (user is null)
        //    {
        //        return BadRequest("Invalid user request!!!");
        //    }
        //    if (user.Name == "girish" && user.Password == "girish123")
        //    {
        //        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigurationManager.AppSetting["JWT:Secret"]));
        //        var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
        //        var tokeOptions = new JwtSecurityToken(issuer: ConfigurationManager.AppSetting["JWT:ValidIssuer"], audience: ConfigurationManager.AppSetting["JWT:ValidAudience"], claims: new List<Claim>(), expires: DateTime.Now.AddMinutes(6), signingCredentials: signinCredentials);
        //        var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
        //        return Ok(new JWTTokenResponse
        //        {
        //            Token = tokenString
        //        });
        //    }
        //    return Unauthorized();
        //}



        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

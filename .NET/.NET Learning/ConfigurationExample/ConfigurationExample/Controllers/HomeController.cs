using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ConfigurationExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly WeatherApiOptions _options;

        public HomeController(IOptions<WeatherApiOptions> weatherApiOption)
        {
            _options = weatherApiOption.Value;
        }


        [Route("/")]
        public IActionResult Index()
        {
            //ViewBag.clientId = _configuration["weatherApi:clientId"];
            //ViewBag.clientSecret = _configuration["weatherApi:clientSecret"];
            // is not x then DEFAULT is 10
            //ViewBag.MyKey = _configuration.GetValue("x", 10);


            //var weatherSection = _configuration.GetSection("weatherApi");
            //ViewBag.clientId = weatherSection["clientId"];
            //ViewBag.clientSecret = weatherSection["clientSecret"];


            // USING OPTION PATTERN
            //var weatherApiOptions = _configuration.GetSection("weatherApi").Get<WeatherApiOptions>();
            //ViewBag.clientId = weatherApiOptions.ClientId;
            //ViewBag.clientSecret = weatherApiOptions.ClientSecret;


            // USING DEPENDENCY INJECTION THROUGH SERVICES
            ViewBag.clientId = _options.ClientId;
            ViewBag.clientSecret = _options.ClientSecret;

            return View();
        }
    }
}

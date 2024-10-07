using Microsoft.AspNetCore.Mvc;
using ServiceContracts;
using Services;

namespace DependencyInjectionExample.Controllers
{
    public class HomeController : Controller
    {

        private readonly ICitiesService _citiesService;

        //  CONSTRUCTOR INJECTION
        public HomeController(ICitiesService citiesService)
        {
            _citiesService = citiesService; //new CitiesService();
        }

        // METHOD INJECTION
        //[Route("/")]
        //public IActionResult Index([FromServices] ICitiesService _citiesService)
        //{
        //    var cities = _citiesService.GetCities();
        //    return View(cities);
        //}

        [Route("/")]
        public IActionResult Index()
        {
            var cities = _citiesService.GetCities();
            return View(cities);
        }
    }
}

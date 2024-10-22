using Microsoft.AspNetCore.Mvc;

namespace EnvironmentsExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }


        //[Route("testing")]
        [Route("/")]
        public IActionResult Index()
        {
            ViewBag.CurrentEnvironment = _webHostEnvironment.EnvironmentName;
            return View();
        }

        //[Route("testing")]
        //public IActionResult testing()
        //{
        //    return View();
        //}
    }
}

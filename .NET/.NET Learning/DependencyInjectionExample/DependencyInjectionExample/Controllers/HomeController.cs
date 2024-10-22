using Autofac;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using ServiceContracts;
using Services;

namespace DependencyInjectionExample.Controllers
{
    public class HomeController : Controller
    {

        private readonly ICitiesService _citiesService1;
        private readonly ICitiesService _citiesService2;
        private readonly ICitiesService _citiesService3;
        //private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly ILifetimeScope _lifeTimeScope;

        //  CONSTRUCTOR INJECTION
        public HomeController(ICitiesService citiesService1, ICitiesService citiesService2, ICitiesService citiesService3, ILifetimeScope lifeTimeScope)
        {
            _citiesService1 = citiesService1; //new CitiesService();
            _citiesService2 = citiesService2; //new CitiesService();
            _citiesService3 = citiesService3; //new CitiesService();
            _lifeTimeScope = lifeTimeScope;
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
            var cities = _citiesService1.GetCities();

            ViewBag.InstaceId_CitiesService_1 = _citiesService1.ServiceInstanceId;
            ViewBag.InstaceId_CitiesService_2 = _citiesService2.ServiceInstanceId;
            ViewBag.InstaceId_CitiesService_3 = _citiesService3.ServiceInstanceId;



            using (ILifetimeScope scope = _lifeTimeScope.BeginLifetimeScope())
            {
                // inject Cities service as child scope
                // service provider responsible for giving objects
                var citiesService = scope.Resolve<ICitiesService>();

                ViewBag.InstanceI_CitiesService_ChildScope = citiesService.ServiceInstanceId;

            } // end of scope; it automatically call dispose method CitiesService.Dispose()



            // child services
            //using (IServiceScope scope = _serviceScopeFactory.CreateScope())
            //{
            //    // inject Cities service as child scope
            //    // service provider responsible for giving objects
            //    var citiesService = scope.ServiceProvider.GetRequiredService<ICitiesService>();

            //    ViewBag.InstanceI_CitiesService_ChildScope = citiesService.ServiceInstanceId;

            //} // end of scope; it automatically call dispose method CitiesService.Dispose()

            return View(cities);
        }
    }
}

using ControllerExample.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControllerExample.Controllers
{
    //public class HomeController : Controller
    //{
    //    public IActionResult Index()
    //    {
    //        return View();
    //    }
    //}

    public class HomeController : Controller
    {
        // ATTRIBUTE ROUTING
        [Route("Home")]
        [Route("/")]
        public ContentResult Home()
        {
            //return Content("Inside home page", "text/plain");
            
            return Content("<h1>Inside home page</h1>", "text/html");
        }        
                
        
        [Route("Person")]
        public JsonResult Person()
        {
            var person = new Person
            {
                Id = Guid.NewGuid(),
                FirstName = "tejas",
                LastName = "mate",
                Age = 23
            };

            return Json(person);

        }


        //[Route("file-download")]
        //public VirtualFileResult FileDownload()
        //{ 

        //    return new VirtualFileResult("/binaryImage.webp", "image/webp");

        //}  
        
        [Route("file-download")]
        public IActionResult FileDownload()
        { 

            return new VirtualFileResult("/binaryImage.webp", "image/webp");

        }


        [Route("Contact")]
        public string Contact()
        {
            return "Inside contact page";
        }        
        
        [Route("About")]
        public string About()
        {
            return "Inside about page";
        }
    }
}

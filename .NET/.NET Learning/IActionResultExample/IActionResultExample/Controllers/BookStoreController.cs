using Microsoft.AspNetCore.Mvc;

namespace IActionResultExample.Controllers
{
    public class BookStoreController : Controller
    {
        [Route("Book-Store")]
        public IActionResult Books(int id)
        {
            return Ok($"Evething is working fine and id is : {id}");
        }
    }
}

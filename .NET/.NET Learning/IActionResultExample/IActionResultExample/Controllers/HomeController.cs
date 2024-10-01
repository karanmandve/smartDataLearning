using Microsoft.AspNetCore.Mvc;

namespace IActionResultExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("Book")]
        public IActionResult Book()
        {
            if (Request.Query.ContainsKey("book-id"))
            {
                var bookId = Request.Query["book-id"];
                //return Ok($"The book id is : {bookId}");
                return RedirectToActionPermanent("Books", "BookStore", new { id = bookId });
            }
            return BadRequest("Book id is not present");
        }
    }
}

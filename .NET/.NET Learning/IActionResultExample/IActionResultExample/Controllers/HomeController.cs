using IActionResultExample.Models;
using Microsoft.AspNetCore.Mvc;

namespace IActionResultExample.Controllers
{
    public class HomeController : Controller
    {
        //[Route("Book")]
        //public IActionResult Book()
        //{
        //    if (Request.Query.ContainsKey("book-id"))
        //    {
        //        var bookId = Request.Query["book-id"];
        //        //return Ok($"The book id is : {bookId}");
        //        return RedirectToActionPermanent("Books", "BookStore", new { id = bookId });
        //    }
        //    return BadRequest("Book id is not present");
        //}


        //// FROM QUERY STRING ?bookId=20 like this
        //[Route("Book")]
        //public IActionResult Book(int? bookId)
        //{
        //    if (bookId == null) {
        //        return BadRequest("Book Id not found");
        //    }
        //    return Ok($"your book id is: {bookId}");
        //}



        // FROM ROUTE AND QUERY STRING
        //[Route("Book/{bookId?}")]
        //public IActionResult Book([FromRoute] int? bookId, [FromQuery] string? bookName)
        //{
        //    if (bookId == null)
        //    {
        //        return BadRequest("Book Id not found");
        //    }

        //    if (bookName == null)
        //    {
        //        return BadRequest("Book name not found");

        //    }

        //    return Ok($"your book id is: {bookId} and book name is: {bookName}");
        //}



        // MODEL BINDING OR MODELDTO
        [Route("Book/{BookId?}/{Author?}")]
        public IActionResult Book([FromQuery] int? bookId, BookDto book)
        {
            if (book.BookId == null)
            {
                return BadRequest("Book Id not found");
            }

            if (book.Author == null)
            {
                return BadRequest("Author name not found");

            }

            return Ok($"{book}");
        }




    }
}

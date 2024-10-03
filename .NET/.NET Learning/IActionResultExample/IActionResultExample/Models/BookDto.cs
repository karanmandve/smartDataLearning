namespace IActionResultExample.Models
{
    public class BookDto
    {
        public int BookId { get; set; }
        public string Author { get; set; }

        public override string ToString()
        {
            return $"Book id is: {BookId} and author name is: {Author}";
        }
    }
}

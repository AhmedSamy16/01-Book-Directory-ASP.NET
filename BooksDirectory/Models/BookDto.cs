using System.ComponentModel.DataAnnotations;

namespace BooksDirectory.Models
{
    public class BookDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
    }
}

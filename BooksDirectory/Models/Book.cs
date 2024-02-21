using System.ComponentModel.DataAnnotations;

namespace BooksDirectory.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "title must 50 or less charachters")]
        public string Title { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "author must 50 or less charachters")]
        public string Author { get; set; }
    }
}

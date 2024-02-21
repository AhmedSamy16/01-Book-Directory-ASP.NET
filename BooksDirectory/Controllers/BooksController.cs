using BooksDirectory.Models;
using BooksDirectory.Services;
using Microsoft.AspNetCore.Mvc;

namespace BooksDirectory.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController(IBooksService booksService) : ControllerBase
    {
        private readonly IBooksService _booksService = booksService;
        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _booksService.GetAllBooksAsync();
            return Ok(books);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById([FromRoute] int id)
        {
            var book = await _booksService.GetBookByIdAsync(id);
            if (book is null)
            {
                return NotFound("Book Not Found");
            }
            return Ok(book);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBook(BookDto bookToCreate)
        {
            var book = await _booksService.CreateBookAsync(bookToCreate);
            return Ok(book);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductById([FromRoute] int id, [FromBody] BookDto bookToUpdate)
        {
            var book = await _booksService.UpdateBookAsync(id, bookToUpdate);
            if (book is null)
            {
                return NotFound("Book Not found");
            }
            return Ok(book);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookById(int id)
        {
            var isProductExist = await _booksService.GetBookByIdAsync(id);

            if (isProductExist == null)
                return NotFound("Book Not Found");

            await _booksService.DeleteBookAsync(isProductExist);
            return NoContent();
        }
    }
}

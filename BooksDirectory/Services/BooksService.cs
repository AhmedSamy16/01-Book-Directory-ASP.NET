using BooksDirectory.Data;
using BooksDirectory.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksDirectory.Services
{
    public class BooksService(ApplicationDbContext context) : IBooksService
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<Book> CreateBookAsync(BookDto bookToCreate)
        {
            var book = new Book
            {
                Title = bookToCreate.Title,
                Author = bookToCreate.Author
            };
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<bool> DeleteBookAsync(Book book)
        {
            _context.Books.Remove(book);
            return await _context.SaveChangesAsync() > 0;
        }

        public Task<List<Book>> GetAllBooksAsync()
        {
            return _context.Books.ToListAsync();
        }

        public Task<Book> GetBookByIdAsync(int id)
        {
            return _context.Books.FindAsync(id).AsTask();
        }

        public async Task<Book> UpdateBookAsync(int id, BookDto bookToUpdate)
        {
            var book = await _context.Books.FindAsync(id);
            if (book is null)
            {
                return null;
            }
            book.Title = bookToUpdate.Title;
            book.Author = bookToUpdate.Author;

            await _context.SaveChangesAsync();
            
            return book;
        }
    }
}

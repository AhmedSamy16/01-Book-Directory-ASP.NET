using BooksDirectory.Models;

namespace BooksDirectory.Services
{
    public interface IBooksService
    {
        Task<List<Book>> GetAllBooksAsync();
        Task<Book> GetBookByIdAsync(int id);
        Task<Book> CreateBookAsync(BookDto bookToCreate);
        Task<bool> DeleteBookAsync(Book book);
        Task<Book> UpdateBookAsync(int id, BookDto book);

    }
}

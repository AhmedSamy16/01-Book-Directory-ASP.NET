using BooksDirectory.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksDirectory.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Book> Books { get; set; }
    }
}

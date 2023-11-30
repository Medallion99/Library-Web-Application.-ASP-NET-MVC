using BookLibrary.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Models.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options): base (options)
        {
            
        }

        public DbSet<Genre> Genre { get; set; }
        public DbSet<Book> Book { get; set; }


    }
}

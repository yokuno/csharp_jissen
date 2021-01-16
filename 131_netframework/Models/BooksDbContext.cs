using System.Data.Entity;

namespace _131_netframework.Models {
    public class BooksDbContext : DbContext {
        public BooksDbContext()
            : base("name=BooksDbContext") {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Author { get; set; }

    }
}


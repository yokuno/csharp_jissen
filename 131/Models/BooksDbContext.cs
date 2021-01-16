using Microsoft.EntityFrameworkCore;

namespace _131.Models {
    public class BooksDbContext : DbContext {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=_131.Models.BooksDbContext");
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Author { get; set; }
    }

}


using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Persistence.DatabaseContext
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options)
            : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<RevitFile> RevitFiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookStoreDbContext).Assembly);
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<Book>()
                .Property(e => e.DateCreated)
                .HasConversion(new UtcDateTimeConverter());

            modelBuilder
                .Entity<Book>()
                .Property(e => e.DateModified)
                .HasConversion(new UtcDateTimeConverter());
        }
    }
}

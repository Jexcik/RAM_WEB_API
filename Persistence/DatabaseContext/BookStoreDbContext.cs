using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Entites;

namespace Persistence.DatabaseContext
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options)
        {

        }

        public DbSet<BookEntity> Books { get; set; }
        public DbSet<RevitFileEntity> RevitFiles { get; set; }
    }
}

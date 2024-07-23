using Application.Contracts.Persistence;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.DatabaseContext;
using Persistence.Entites;

namespace Persistence.Repositories
{
    public class BooksRepository : GenericRepository<Book>, IBooksRepository
    {
        public BooksRepository(BookStoreDbContext bookStoreDbContext)
            : base(bookStoreDbContext) { }
    }
}

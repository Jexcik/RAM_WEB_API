using Application.Contracts.Persistence;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.DatabaseContext;
using Persistence.Entites;

namespace Persistence.Repositories
{
    public class RevitFilesRepository : GenericRepository<RevitFile>, IFilesRepository
    {
        public RevitFilesRepository(BookStoreDbContext bookStoreDbContext)
            : base(bookStoreDbContext) { }
    }
}

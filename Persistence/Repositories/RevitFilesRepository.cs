using Application.Contracts.Persistence;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.DatabaseContext;

namespace Persistence.Repositories
{
    public class RevitFilesRepository : IRevitFilesRepository
    {
        private readonly BookStoreDbContext _context;

        public RevitFilesRepository(BookStoreDbContext context)
        {
            _context = context;
        }
        public async Task<List<RevitFile>> GetAll()
        {
            var rvtFileEntities = await _context.RevitFiles
                .AsNoTracking()
                .ToListAsync();

            var rvtFiles = rvtFileEntities
                .Select(r => RevitFile.Create(r.FileName, r.FilePath, r.Creator, r.Editor, (DateTime)r.DateCreation, (DateTime)r.DateChange).file)
                .ToList();

            return rvtFiles;
        }

        public Task<Guid> Create(RevitFile file)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> Update()
        {
            throw new NotImplementedException();
        }
    }
}

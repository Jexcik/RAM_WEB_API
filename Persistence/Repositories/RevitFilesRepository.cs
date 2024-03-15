using Application.Contracts.Persistence;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.DatabaseContext;
using Persistence.Entites;

namespace Persistence.Repositories
{
    public class RevitFilesRepository : IFilesRepository
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
                .Select(r => RevitFile
                .Create(r.FileName, r.FilePath, r.Creator, r.Editor, (DateTime)r.DateCreation, (DateTime)r.DateChange).file)
                .ToList();

            return rvtFiles;
        }

        public async Task<Guid> Create(RevitFile file)
        {
            var rvtFileEntity = new RevitFileEntity
            {
                Id = file.Id,
                FileName = file.FileName,
                FilePath = file.FilePath,
                Creator = file.Creator,
                Editor = file.Editor,
                DateCreation = file.DateCreation,
                DateChange = file.DateChange
            };

            await _context.RevitFiles.AddAsync(rvtFileEntity);
            await _context.SaveChangesAsync();

            return rvtFileEntity.Id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.RevitFiles.Where(rvt => rvt.Id == id).ExecuteDeleteAsync();

            return id;
        }

        public async Task<Guid> Update(Guid id, string fileName, string filePath, string editor, DateTime dateChange)
        {
            await _context.RevitFiles
                 .Where(rt => rt.Id == id)
                 .ExecuteUpdateAsync(s => s
                 .SetProperty(rt => rt.FileName, rt => fileName)
                 .SetProperty(rt => rt.FilePath, rt => filePath)
                 .SetProperty(rt => rt.Editor, rt => editor)
                 .SetProperty(rt => rt.DateChange, rt => dateChange));

            return id;
        }
    }
}

using Application.Contracts.Persistence;
using Application.Contracts.Services;
using Domain.Models;

namespace Application.Services
{
    public class FilesService : IFilesService
    {
        private readonly IRevitFilesRepository _revitFilesRepository;
        public Task<Guid> CreateFile(RevitFile file)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> DeleteFile(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<RevitFile>> GetAllFile()
        {
            throw new NotImplementedException();
        }

        public Task<Guid> UpdateFile()
        {
            throw new NotImplementedException();
        }
    }
}

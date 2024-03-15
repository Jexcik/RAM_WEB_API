using Application.Contracts.Persistence;
using Application.Contracts.Services;
using Domain.Models;

namespace Application.Services
{
    public class FilesService : IFilesService
    {
        private readonly IFilesRepository _revitFilesRepository;
        public FilesService(IFilesRepository revitFilesRepository)
        {
            _revitFilesRepository = revitFilesRepository;
        }
        public async Task<List<RevitFile>> GetAllFiles()
        {
            return await _revitFilesRepository.GetAll();
        }

        public async Task<Guid> CreateFile(RevitFile file)
        {
            return await _revitFilesRepository.Create(file);
        }

        public async Task<Guid> DeleteFile(Guid Id)
        {
            return await _revitFilesRepository.Delete(Id);
        }

        public async Task<Guid> UpdateFile(Guid id, string fileName, string filePath, string editor, DateTime dateChange)
        {
            return await _revitFilesRepository.Update(id, fileName, filePath, editor, dateChange);
        }
    }
}

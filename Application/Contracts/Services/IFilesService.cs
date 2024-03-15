using Domain.Models;

namespace Application.Contracts.Services
{
    public interface IFilesService
    {
        Task<Guid> CreateFile(RevitFile file);
        Task<Guid> DeleteFile(Guid Id);
        Task<List<RevitFile>> GetAllFiles();
        Task<Guid> UpdateFile(Guid id, string fileName, string filePath, string editor, DateTime dateChange);
    }
}

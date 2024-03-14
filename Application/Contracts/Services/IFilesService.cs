using Domain.Models;

namespace Application.Contracts.Services
{
    public interface IFilesService
    {
        Task<Guid> CreateFile(RevitFile file);
        Task<Guid> DeleteFile(Guid Id);
        Task<List<RevitFile>> GetAllFile();
        Task<Guid> UpdateFile();
    }
}

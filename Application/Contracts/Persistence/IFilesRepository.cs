using Domain.Models;

namespace Application.Contracts.Persistence
{
    public interface IFilesRepository
    {
        Task<Guid> Create(RevitFile file);
        Task<Guid> Delete(Guid id);
        Task<List<RevitFile>> GetAll();
        Task<Guid> Update(Guid id, string fileName, string filePath, string editor, DateTime dateChange);
    }
}

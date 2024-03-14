using Domain.Models;

namespace Application.Contracts.Persistence
{
    public interface IRevitFilesRepository
    {
        Task<Guid> Create(RevitFile file);
        Task<Guid> Delete(Guid id);
        Task<List<RevitFile>> GetAll();
        Task<Guid> Update();
    }
}

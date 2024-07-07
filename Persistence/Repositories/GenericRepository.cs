using Application.Contracts.Persistence;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Persistence.DatabaseContext;

namespace Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T>
        where T : BaseEntity
    {
        private readonly BookStoreDbContext _bookStoreDbContext;

        public GenericRepository(BookStoreDbContext bookStoreDbContext)
        {
            _bookStoreDbContext = bookStoreDbContext;
        }

        public async Task CreateAsync(T entity)
        {
            await _bookStoreDbContext.AddAsync(entity);
            await _bookStoreDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _bookStoreDbContext.Remove(entity);
            await _bookStoreDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _bookStoreDbContext.Entry(entity).State = EntityState.Modified;
            await _bookStoreDbContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync()
        {
            return await _bookStoreDbContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return (await _bookStoreDbContext.Set<T>().FindAsync(id))!;
        }
    }
}

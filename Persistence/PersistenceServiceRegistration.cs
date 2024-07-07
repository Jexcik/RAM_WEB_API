using Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.DatabaseContext;
using Persistence.Repositories;

namespace Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddDbContext<BookStoreDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("BookStoreConnectionString"));
        });
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IBooksRepository, BooksRepository>();
        services.AddScoped<IFilesRepository, RevitFilesRepository>();
        return services;
    }
}

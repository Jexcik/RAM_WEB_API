using System.Reflection;
using Application.Contracts.Services;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(configuration =>
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())
        );
        services.AddScoped<IBooksService, BooksService>();
        services.AddScoped<IFilesService, FilesService>();
        return services;
    }
}

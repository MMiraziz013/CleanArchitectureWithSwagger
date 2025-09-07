using Clean.Application.Abstractions;
using Clean.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Clean.Infrastructure;

// The class itself must be static to contain extension methods.
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        // Register your concrete implementations with their interfaces.
        // These implementations are now accessible by the WebApi project.
        services.AddTransient<IStudentContext, StudentContext>();
        services.AddTransient<IAppDbContext, AppDbContext>();
        
        return services;
    }
}
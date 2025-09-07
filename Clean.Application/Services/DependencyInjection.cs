using Microsoft.Extensions.DependencyInjection;

namespace Clean.Application.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddTransient<IStudentService, StudentService>();

        return services;
    }
}
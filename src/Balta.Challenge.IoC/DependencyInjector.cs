using Balta.Challenge.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Balta.Challenge.IoC;

public static class DependencyInjector
{
    public static IServiceCollection DependencyInjectorApi(this IServiceCollection services, IConfiguration configuration)
    {
        return services.DependencyInjectorDbContext(configuration);
    }

    private static IServiceCollection DependencyInjectorDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApiDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        });

        return services;
    }
}

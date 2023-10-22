using Balta.Challenge.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Balta.Challenge.IoC;

public static class DependencyInjector
{
    public static IServiceCollection DependencyInjectorApi(this IServiceCollection services, IConfiguration configuration)
    {
        services.DependencyInjectorDbContext(configuration);
        services.DependencyInjectorAccountContext(configuration);

        return services;
    }

    private static IServiceCollection DependencyInjectorDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApiDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        });

        return services;
    }

    private static IServiceCollection DependencyInjectorAccountContext(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddTransient<
            Core.Contexts.Account.UseCases.Create.Contracts.IRepository,
            Data.Contexts.Account.UseCases.Create.Repository>();

        services.AddTransient<
            Core.Contexts.Account.UseCases.Authenticate.Contracts.IRepository,
            Data.Contexts.Account.UseCases.Authenticate.Repository>();

        return services;
    }
}

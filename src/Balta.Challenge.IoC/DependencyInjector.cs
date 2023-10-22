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
        services.DependencyInjectorContext();

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

    private static IServiceCollection DependencyInjectorContext(
        this IServiceCollection services
       )
    {
        #region Account
        services.AddTransient<
            Core.Contexts.Account.UseCases.Create.Contracts.IRepository,
            Data.Contexts.Account.UseCases.Create.Repository>();
        #endregion

        #region Authenticate

        services.AddTransient<
            Core.Contexts.Account.UseCases.Authenticate.Contracts.IRepository,
            Data.Contexts.Account.UseCases.Authenticate.Repository>();
        #endregion

        #region Adress
        services.AddTransient<
           Core.Contexts.Address.UseCases.Read.Contracts.IRepository,
           Data.Contexts.Address.UseCases.Read.Repository>();

        services.AddTransient<
         Core.Contexts.Address.UseCases.Create.Contracts.IRepository,
         Data.Contexts.Address.UseCases.Create.Repository>();
        #endregion

        return services;
    }
}

using Balta.Challenge.Core;
using System.Reflection;

namespace Balta.Challenge.Web.Extensions;

public static class BuilderExtension
{
    public static void AddConfigurations(this WebApplicationBuilder builder)
    {
        //Configuration.Password.Salt = builder.Configuration["PasswordConfiguration:Salt"];
        Configuration.Jwt.JwtPrivateKey = builder.Configuration["JwtConfiguration:JwtPrivateKew"];
    }

    public static void AddMediator(this WebApplicationBuilder builder)
    {
        builder.Services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(Configuration).Assembly));
    }
}

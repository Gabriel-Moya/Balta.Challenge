using Microsoft.OpenApi.Models;

namespace Balta.Challenge.Web.Startup;

public static class ConfigureSwagger
{
    public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen(c =>
        {
            c.CustomSchemaIds(type => type.ToString());
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Desafio Balta", Description = "Api criada para desafio Balta.", Version = "v1" });

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Name = "Authorization",
                Description = "Bearer {token}"
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });

        return services;
    }

    public static WebApplication UseSwaggerConfiguration(this WebApplication app)
    {
        app.UseSwagger();

        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiDesafioBalta v1");
        });

        app.MapGet("/", (HttpContext context) =>
        {
            context.Response.Redirect("/swagger");
            return Task.CompletedTask;
        });

        return app;
    }
}

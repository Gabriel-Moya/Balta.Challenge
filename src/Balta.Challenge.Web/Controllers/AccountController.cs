using Balta.Challenge.Web.Extensions;
using MediatR;

namespace Balta.Challenge.Web.Controllers;

public static class AccountController
{
    public static void MapAccountEndpoints(this WebApplication app)
    {
        // Create
        app.MapPost("/api/v1/accounts", async (
            Core.Contexts.Account.UseCases.Create.Request request,
            IRequestHandler<
                Core.Contexts.Account.UseCases.Create.Request,
                Core.Contexts.Account.UseCases.Create.Response> handler) =>
        {
            var result = await handler.Handle(request, new CancellationToken());
            return result.IsSuccess
                ? Results.Created($"/api/v1/account/{result.Data?.Id}", result.Data)
                : Results.Json(result, statusCode: result.StatusCode);
        });

        // Authenticate
        app.MapPost("/api/v1/authenticate", async (
            Core.Contexts.Account.UseCases.Authenticate.Request request,
            IRequestHandler<
                Core.Contexts.Account.UseCases.Authenticate.Request,
                Core.Contexts.Account.UseCases.Authenticate.Response> handler) =>
        {
            var result = await handler.Handle(request, new CancellationToken());

            if (!result.IsSuccess)
                return Results.Json(result, statusCode: result.StatusCode);

            if (result.Data is null)
                return Results.Json(result, statusCode: 500);

            result.Data.Token = JwtExtensions.Generate(result.Data);
            return Results.Ok(result);
        });
    }
}

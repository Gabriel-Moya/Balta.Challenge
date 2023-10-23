using Balta.Challenge.Core.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

using Balta.Challenge.Core.Contexts.Address.UseCases.Read;

namespace Balta.Challenge.Web.Controllers;
public static class LocaleController
{
    public static void MapLocaleEndpoints(this WebApplication app)
    {
        app.MapPost("/api/v1/locales", async (
            Core.Contexts.Address.UseCases.Create.Request request,
            IRequestHandler<
                Core.Contexts.Address.UseCases.Create.Request,
                Core.Contexts.Address.UseCases.Create.Response> handler) =>
        {
            var result = await handler.Handle(request, new CancellationToken());
            return result.IsSuccess
                ? Results.Created($"/api/v1/locale/{result.Data?.Id}", result.Data)
                : Results.Json(result, statusCode: result.StatusCode);
        });

        app.MapGet("/api/v1/locales", async (
            [FromQuery] string expression,
            [FromQuery] FilterEnum filter,
            IRequestHandler<Request, Response> handler) =>
         {
             var request = new Request(expression, filter);

             var result = await handler.Handle(request, new CancellationToken());
             return result.IsSuccess
                ? Results.Ok(result)
                : Results.Json(result, statusCode: result.StatusCode);
         });

        app.MapPut("/api/v1/locales/", async (
            Core.Contexts.Address.UseCases.Update.Request request,
            IRequestHandler<
                Core.Contexts.Address.UseCases.Update.Request,
                Core.Contexts.Address.UseCases.Update.Response> handler) =>
        {
            var result = await handler.Handle(request, new CancellationToken());
            return result.IsSuccess
                ? Results.Ok(result)
                : Results.Json(result, statusCode: result.StatusCode);
        });

        app.MapDelete("/api/v1/locales/", async (
            [FromBody] Core.Contexts.Address.UseCases.Delete.Request request,
            IRequestHandler<
                Core.Contexts.Address.UseCases.Delete.Request,
                Core.Contexts.Address.UseCases.Delete.Response> handler) =>
        {
            var result = await handler.Handle(request, new CancellationToken());
            return result.IsSuccess
                ? Results.Ok(result)
                : Results.Json(result, statusCode: result.StatusCode);
        });
    }
}

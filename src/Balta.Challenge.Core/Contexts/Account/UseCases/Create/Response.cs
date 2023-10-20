using Flunt.Notifications;

namespace Balta.Challenge.Core.Contexts.Account.UseCases.Create;

public class Response : Shared.UseCases.Response
{
    public Response(string message, int statusCode, IEnumerable<Notification>? notifications = null)
    {
        Message = message;
        StatusCode = statusCode;
        Notifications = notifications;
    }

    public Response(string message, ResponseData data)
    {
        Message = message;
        StatusCode = 201;
        Notifications = null;
        Data = data;
    }

    public ResponseData? Data { get; set; }
}

public record ResponseData(Guid Id, string Name, string Email);

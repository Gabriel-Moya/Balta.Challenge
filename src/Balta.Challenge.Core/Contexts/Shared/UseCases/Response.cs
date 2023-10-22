using Flunt.Notifications;

namespace Balta.Challenge.Core.Contexts.Shared.UseCases;

public abstract class Response
{
    public string Message { get; set; } = string.Empty;
    public int StatusCode { get; set; }
    public bool IsSuccess => StatusCode >= 200 && StatusCode <= 299;
    public IEnumerable<Notification>? Notifications { get; set; }
}

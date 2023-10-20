using Flunt.Notifications;

namespace Balta.Challenge.Core.Contexts.Shared.UseCases;

public abstract class Response
{
    public string Message { get; set; } = string.Empty;
    public int StatusCode { get; set; }
    public bool IsSuccess { get; set; }
    public IEnumerable<Notification>? Notifications { get; set; }
}

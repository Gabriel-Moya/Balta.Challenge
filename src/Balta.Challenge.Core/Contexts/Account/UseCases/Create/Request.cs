using MediatR;

namespace Balta.Challenge.Core.Contexts.Account.UseCases.Create;

public record Request(string Name, string Email, string Password) : IRequest<Response>;

using MediatR;

namespace Balta.Challenge.Core.Contexts.Account.UseCases.Authenticate;

public record Request(string Email, string Password) : IRequest<Response>;

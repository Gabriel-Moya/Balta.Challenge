using MediatR;

namespace Balta.Challenge.Core.Contexts.Address.UseCases.Create;

public record Request(int Id, string State, string City) : IRequest<Response>;


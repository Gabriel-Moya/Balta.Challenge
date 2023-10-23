using MediatR;

namespace Balta.Challenge.Core.Contexts.Address.UseCases.Delete;

public record Request(int Id) : IRequest<Response>;

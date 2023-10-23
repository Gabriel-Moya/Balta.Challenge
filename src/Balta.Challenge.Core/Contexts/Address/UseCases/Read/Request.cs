using Balta.Challenge.Core.Enums;
using MediatR;

namespace Balta.Challenge.Core.Contexts.Address.UseCases.Read;
public record Request(string expression, FilterEnum filter) : IRequest<Response>;



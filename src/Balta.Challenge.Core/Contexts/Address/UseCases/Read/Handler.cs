using Balta.Challenge.Core.Contexts.Address.UseCases.Read.Contracts;
using MediatR;

namespace Balta.Challenge.Core.Contexts.Address.UseCases.Read;
public class Handler : IRequestHandler<Request, Response>
{
    private readonly IRepository _repository;

    public Handler(IRepository repository)
        => _repository = repository;

    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        try
        {
            var res = Specification.Ensure(request);
            if (!res.IsValid)
                return new Response("Dados inválidos", 400, res.Notifications);
        }
        catch
        {
            return new Response("Não foi possível validar os dados", 500);
        }


       var result = await _repository.GetListByExpressionAndFilter(request.expression, request.filter, cancellationToken);


        return new Response("Busca realizada com sucesso", new ResponseData(result));
    }
}

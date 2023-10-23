using Balta.Challenge.Core.Contexts.Address.Entities;
using Balta.Challenge.Core.Contexts.Address.UseCases.Delete.Contracts;
using MediatR;

namespace Balta.Challenge.Core.Contexts.Address.UseCases.Delete;

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

        Locale existingLocale;
        try
        {
            existingLocale = await _repository.GetLocaleById(request.Id, cancellationToken);
            if (existingLocale is null)
                return new Response("Não foi possível localizar o código enviado", 400);
        }
        catch
        {
            return new Response("Não foi possível verificar a cidade", 500);
        }

        try
        {
            await _repository.RemoveAsync(existingLocale, cancellationToken);
        }
        catch
        {
            return new Response("Não foi possível salvar a cidade", 500);
        }

        return new Response("Cidade criada com sucesso", new ResponseData(existingLocale.Id, existingLocale.State.Value, existingLocale.City));
    }
}

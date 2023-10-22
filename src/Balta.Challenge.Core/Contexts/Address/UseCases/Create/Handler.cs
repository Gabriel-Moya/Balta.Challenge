using Balta.Challenge.Core.Contexts.Address.UseCases.Create.Contracts;
using Balta.Challenge.Core.Contexts.Address.ValueObjects;
using Balta.Challenge.Core.Contexts.Address.Entities;
using MediatR;

namespace Balta.Challenge.Core.Contexts.Address.UseCases.Create;
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

        State state;
        IBGECode id;
        Locale locale;

        try
        {
            state = State.Create(request.State);
            id = IBGECode.Create(request.Id);
            locale = new Locale(id, state, request.City);
        }
        catch (Exception ex)
        {
            return new Response(ex.Message, 400);
        }

        try
        {
            var exists = await _repository.AnyAsync(request.Id, cancellationToken);
            if (exists)
                return new Response("Código do IBGE já está cadastrado", 400);
        }
        catch
        {
            return new Response("Não foi possível verificar a cidade", 500);
        }

        try
        {
            await _repository.SaveAsync(locale, cancellationToken);
        }
        catch
        {
            return new Response("Não foi possível salvar a cidade", 500);
        }

        return new Response("Cidade criada com sucesso", new ResponseData(locale.IBGECode.Value,locale.State.Value,locale.City));
    }
}

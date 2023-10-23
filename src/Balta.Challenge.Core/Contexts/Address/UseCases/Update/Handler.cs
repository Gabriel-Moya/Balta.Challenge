using Balta.Challenge.Core.Contexts.Address.UseCases.Update.Contracts;
using Balta.Challenge.Core.Contexts.Address.ValueObjects;
using Balta.Challenge.Core.Contexts.Address.Entities;
using MediatR;

namespace Balta.Challenge.Core.Contexts.Address.UseCases.Update;

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

        Locale existingLocale;
        try
        {
            existingLocale = await _repository.GetLocaleById(request.Id, cancellationToken);
            if (existingLocale is null)
                return new Response("Não foi possível localizar o código enviado", 400);

            existingLocale.Id = locale.Id;
            existingLocale.State = locale.State;
            existingLocale.City = locale.City;
        }
        catch
        {
            return new Response("Não foi possível verificar a cidade", 500);
        }

        try
        {
            await _repository.UpdateAsync(existingLocale, cancellationToken);
        }
        catch
        {
            return new Response("Não foi possível atualizar a cidade", 500);
        }

        return new Response("Cidade atualizada com sucesso", new ResponseData(existingLocale.Id, existingLocale.State.Value, existingLocale.City));
    }
}

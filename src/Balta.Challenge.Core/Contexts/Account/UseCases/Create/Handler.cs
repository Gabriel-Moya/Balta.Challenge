using Balta.Challenge.Core.Contexts.Account.Entities;
using Balta.Challenge.Core.Contexts.Account.UseCases.Create.Contracts;
using Balta.Challenge.Core.Contexts.Account.ValueObjects;
using MediatR;

namespace Balta.Challenge.Core.Contexts.Account.UseCases.Create;

public class Handler : IRequestHandler<Request, Response>
{
    private readonly IRepository _repository;

    public Handler(IRepository repository)
        => _repository = repository;

    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        // Validate request
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

        // Generate objects
        Email email;
        Password password;
        User user;

        try
        {
            email = Email.Create(request.Email);
            password = Password.Create(request.Password);
            user = new User(request.Name, email, password);
        }
        catch (Exception ex)
        {
            return new Response(ex.Message, 400);
        }

        // Check if user exists
        try
        {
            var exists = await _repository.AnyAsync(email.Address, cancellationToken);
            if (exists)
                return new Response("Usuário já cadastrado", 400);
        }
        catch
        {
            return new Response("Não foi possível verificar o usuário", 500);
        }

        // Save user
        try
        {
            await _repository.SaveAsync(user, cancellationToken);
        }
        catch
        {
            return new Response("Não foi possível salvar o usuário", 500);
        }

        return new Response("Conta criada com sucesso", new ResponseData(user.Id, user.Name, user.Email));
    }
}

using Balta.Challenge.Core.Contexts.Account.Entities;
using Balta.Challenge.Core.Contexts.Account.UseCases.Authenticate.Contracts;
using MediatR;

namespace Balta.Challenge.Core.Contexts.Account.UseCases.Authenticate;

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

        // Recover profile
        User? user;
        try
        {
            user = await _repository.GetUserByEmailAsync(request.Email, cancellationToken);
            if (user is null)
                return new Response("Usuário não encontrado", 404);
        }
        catch
        {
            return new Response("Não foi possível verificar o usuário", 500);
        }

        // Check if is valid password
        if (!user.Password.PasswordIsValid(request.Password))
            return new Response("Usuário ou senha inválidos", 400);

        // Return data
        try
        {
            var data = new ResponseData
            {
                Id = user.Id.ToString(),
                Name = user.Name,
                Email = user.Email,
            };

            return new Response("", data);
        }
        catch
        {
            return new Response("Não foi possível recuperar os dados do perfil", 500);
        }
    }
}

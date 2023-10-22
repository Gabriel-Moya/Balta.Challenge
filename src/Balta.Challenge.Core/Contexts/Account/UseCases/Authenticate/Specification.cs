using Balta.Challenge.Core.Contexts.Account.UseCases.Create;
using Flunt.Notifications;
using Flunt.Validations;

namespace Balta.Challenge.Core.Contexts.Account.UseCases.Authenticate;

public class Specification
{
    public static Contract<Notification> Ensure(Request request)
        => new Contract<Notification>()
            .Requires()
            .IsLowerThan(request.Password.Length, 30, "Password", "A senha deve ter no máximo 30 caracteres")
            .IsGreaterThan(request.Password.Length, 7, "Password", "A senha deve ter no mínimo 8 caracteres")
            .IsEmail(request.Email, "Email", "E-mail inválido");
}

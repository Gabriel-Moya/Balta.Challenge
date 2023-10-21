using Flunt.Notifications;
using Flunt.Validations;

namespace Balta.Challenge.Core.Contexts.Account.UseCases.Create;

public class Specification
{
    public static Contract<Notification> Ensure(Request request)
        => new Contract<Notification>()
            .Requires()
            .IsNotNullOrEmpty(request.Name, "Name", "O nome é obrigatório")
            .IsEmail(request.Email, "Email", "O e-mail é inválido")
            .IsNotNullOrEmpty(request.Password, "Password", "A senha é obrigatória")
            .IsEmail(request.Email, "Email", "E-mail inválido");
}

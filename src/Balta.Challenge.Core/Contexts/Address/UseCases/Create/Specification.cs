using Flunt.Notifications;
using Flunt.Validations;

namespace Balta.Challenge.Core.Contexts.Address.UseCases.Create;
public class Specification
{
    public static Contract<Notification> Ensure(Request request)
   => new Contract<Notification>()
        .Requires()
            .IsNotNullOrEmpty(request.State, "State", "Nome do estado é obrigatório")
            .IsNotNullOrEmpty(request.City, "City", "Nome da cidade é obrigatório");
}

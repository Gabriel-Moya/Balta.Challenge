using Flunt.Notifications;
using Flunt.Validations;

namespace Balta.Challenge.Core.Contexts.Address.UseCases.Delete;

public class Specification
{
    public static Contract<Notification> Ensure(Request request)
   => new Contract<Notification>()
        .Requires()
        .IsNotNull(request.Id, "Id", "O ID é obrigatório");
}

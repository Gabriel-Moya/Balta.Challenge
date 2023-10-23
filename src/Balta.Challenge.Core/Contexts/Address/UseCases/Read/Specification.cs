using Flunt.Notifications;
using Flunt.Validations;

namespace Balta.Challenge.Core.Contexts.Address.UseCases.Read;
public class Specification
{
    public static Contract<Notification> Ensure(Request request)
   => new Contract<Notification>()
        .Requires()
            .IsNotNullOrEmpty(request.expression, "Expression", "Expressão de busca é obrigatória")
            .IsNotNullOrEmpty(request.filter.ToString(), "Filter", "Filtro é obrigatório");
}

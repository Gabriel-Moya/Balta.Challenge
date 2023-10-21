using Balta.Challenge.Core.Contexts.Account.Entities;

namespace Balta.Challenge.Core.Contexts.Account.UseCases.Create.Contracts;

public interface IRepository
{
    Task<bool> AnyAsync(string email, CancellationToken cancellationToken);
    Task SaveAsync(User user, CancellationToken cancellationToken);
}

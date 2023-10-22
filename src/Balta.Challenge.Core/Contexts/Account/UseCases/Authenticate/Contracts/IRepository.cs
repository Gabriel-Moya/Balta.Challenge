using Balta.Challenge.Core.Contexts.Account.Entities;

namespace Balta.Challenge.Core.Contexts.Account.UseCases.Authenticate.Contracts;

public interface IRepository
{
    Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken);
}

using Balta.Challenge.Core.Contexts.Address.Entities;

namespace Balta.Challenge.Core.Contexts.Address.UseCases.Create.Contracts;

public interface IRepository
{
    Task<bool> AnyAsync(int id, CancellationToken cancellationToken);
    Task SaveAsync(Locale locale, CancellationToken cancellationToken);
}

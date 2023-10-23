using Balta.Challenge.Core.Contexts.Address.Entities;

namespace Balta.Challenge.Core.Contexts.Address.UseCases.Update.Contracts;

public interface IRepository
{
    Task<Locale> GetLocaleById(int id, CancellationToken cancellationToken);
    Task UpdateAsync(Locale locale, CancellationToken cancellationToken);
}

using Balta.Challenge.Core.Contexts.Address.Entities;

namespace Balta.Challenge.Core.Contexts.Address.UseCases.Create.Contracts;

public interface IRepository
{
    Task<bool> AnyAsync(int id);
    Task SaveAsync(Locale locale);
}

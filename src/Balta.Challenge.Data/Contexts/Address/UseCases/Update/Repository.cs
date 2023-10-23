using Balta.Challenge.Core.Contexts.Address.Entities;
using Balta.Challenge.Core.Contexts.Address.UseCases.Update.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Balta.Challenge.Data.Contexts.Address.UseCases.Update;

public class Repository : IRepository
{
    private readonly ApiDbContext _context;

    public Repository(ApiDbContext context)
    {
        _context = context;
    }

    public Task<Locale> GetLocaleById(int id, CancellationToken cancellationToken)
    {
        return _context.Locales
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public Task UpdateAsync(Locale locale, CancellationToken cancellationToken)
    {
        _context.Locales.Update(locale);
        return _context.SaveChangesAsync(cancellationToken);
    }
}

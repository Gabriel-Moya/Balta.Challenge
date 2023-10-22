using Balta.Challenge.Core.Contexts.Address.Entities;
using Balta.Challenge.Core.Contexts.Address.UseCases.Create.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Balta.Challenge.Data.Contexts.Address.UseCases.Create;
public class Repository : IRepository
{
    private readonly ApiDbContext _context;

    public Repository(ApiDbContext context)
        => _context = context;

    public Task<bool> AnyAsync(int value, CancellationToken cancellationToken)
        => _context
            .Locales
            .AsNoTracking()
            .Include(x => x.IBGECode)
            .AnyAsync(x => x.IBGECode.Value == value, cancellationToken);

    public async Task SaveAsync(Locale locale, CancellationToken cancellationToken)
    {
        await _context.AddAsync(locale, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}

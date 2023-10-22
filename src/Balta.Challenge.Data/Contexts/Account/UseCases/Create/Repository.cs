using Balta.Challenge.Core.Contexts.Account.Entities;
using Balta.Challenge.Core.Contexts.Account.UseCases.Create.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Balta.Challenge.Data.Contexts.Account.UseCases.Create;

public class Repository : IRepository
{
    private readonly ApiDbContext _context;

    public Repository(ApiDbContext context)
        => _context = context;

    public Task<bool> AnyAsync(string email, CancellationToken cancellationToken)
        => _context
            .Users
            .AsNoTracking()
            .AnyAsync(x => x.Email == email, cancellationToken);

    public async Task SaveAsync(User user, CancellationToken cancellationToken)
    {
        await _context.AddAsync(user, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}

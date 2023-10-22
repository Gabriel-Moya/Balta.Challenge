using Balta.Challenge.Core.Contexts.Account.Entities;
using Balta.Challenge.Core.Contexts.Account.UseCases.Authenticate.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Balta.Challenge.Data.Contexts.Account.UseCases.Authenticate;

public class Repository : IRepository
{
    private readonly ApiDbContext _context;

    public Repository(ApiDbContext context)
        => _context = context;

    public Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken)
        => _context
            .Users
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
}

using Balta.Challenge.Core.Contexts.Account.Entities;
using Balta.Challenge.Core.Contexts.Address.Entities;
using Balta.Challenge.Core.Contexts.Address.ValueObjects;
using Balta.Challenge.Data.Contexts.Account.Mappings;
using Balta.Challenge.Data.Contexts.Address.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Balta.Challenge.Data;

public class ApiDbContext : DbContext
{
    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Locale> Locales { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new UserMapping());

        builder.ApplyConfiguration(new LocaleMapping());
    }
}

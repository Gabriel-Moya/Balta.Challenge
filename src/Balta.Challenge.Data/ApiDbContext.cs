using Balta.Challenge.Core.Contexts.Account.Entities;
using Balta.Challenge.Data.Contexts.Account.Mappings;
using Balta.Challenge.Domain;
using Microsoft.EntityFrameworkCore;

namespace Balta.Challenge.Data;

public class ApiDbContext : DbContext
{
    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; } = null!;

    //public DbSet<Teste> Teste { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new UserMapping());
    }
}

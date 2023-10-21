using System.Reflection;
using Balta.Challenge.Domain;
using Microsoft.EntityFrameworkCore;

namespace Balta.Challenge.Data;

public class ApiDbContext : DbContext
{
    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }

    public DbSet<Teste> Teste { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    }
}

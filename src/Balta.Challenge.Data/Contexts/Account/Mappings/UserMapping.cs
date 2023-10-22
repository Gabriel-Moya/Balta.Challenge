using Balta.Challenge.Core.Contexts.Account.Entities;
using Balta.Challenge.Core.Contexts.Account.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Balta.Challenge.Data.Contexts.Account.Mappings;

public class UserMapping : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        var emailConverter = new ValueConverter<Email, string>(
            v => v.ToString(),
            v => Email.Create(v));

        var passwordConverter = new ValueConverter<Password, string>(
            v => v.ToString(),
            v => Password.Create(v));

        builder.ToTable("Users");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasColumnName("Name")
            .HasColumnType("VARCHAR")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Email)
            .HasColumnName("Email")
            .HasConversion(emailConverter)
            .HasColumnType("VARCHAR")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Password)
            .HasColumnName("Password")
            .HasConversion(passwordConverter)
            .HasColumnType("VARCHAR")
            .HasMaxLength(100)
            .IsRequired();
    }
}

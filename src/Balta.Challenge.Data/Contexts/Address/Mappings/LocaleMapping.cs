using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Balta.Challenge.Core.Contexts.Address.Entities;

namespace Balta.Challenge.Data.Contexts.Address.Mappings;
public class LocaleMapping : IEntityTypeConfiguration<Locale>
{
    public void Configure(EntityTypeBuilder<Locale> builder)
    {
        builder.ToTable("Locales");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
          .HasColumnName("id");

        builder.OwnsOne(x => x.State)
         .Property(x => x.Value)
         .HasColumnName("state");

        builder
        .Property(x => x.City)
        .HasColumnName("city");
    }
}

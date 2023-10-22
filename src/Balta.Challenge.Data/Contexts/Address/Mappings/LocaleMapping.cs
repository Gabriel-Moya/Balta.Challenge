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

        builder.OwnsOne(x => x.IBGECode)
          .Property(x => x.Value)
          .HasColumnName("IBGEcode");

        builder.OwnsOne(x => x.State)
         .Property(x => x.Value)
         .HasColumnName("State");

        builder
        .Property(x => x.City)
        .HasColumnName("City");
    }
}

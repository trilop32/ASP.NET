using Teledok.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Teledok.Persistence.EntityTypeConfigurations;

public class FounderConfiguration : IEntityTypeConfiguration<Founder>
{
    public void Configure(EntityTypeBuilder<Founder> builder)
    {
        builder.HasKey(founder => founder.INN);
        builder.HasIndex(founder => founder.INN).IsUnique();
    }
}
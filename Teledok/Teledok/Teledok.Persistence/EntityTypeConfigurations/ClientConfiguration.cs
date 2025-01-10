using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Teledok.Domain;

namespace Teledok.Persistence.EntityTypeConfigurations;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.HasKey(client => client.INN);

        builder.HasIndex(client => client.INN)
            .IsUnique();

        builder.Property(client => client.INN)
            .HasMaxLength(12);
    }
}
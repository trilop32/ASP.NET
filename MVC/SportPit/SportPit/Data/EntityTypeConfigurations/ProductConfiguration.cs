using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportPit.Models;

namespace SportPit.Data.EntityTypeConfigurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder
            .ToTable("products");

        builder
            .HasKey(product => product.Id);

        builder
            .HasIndex(client => client.Id)
            .IsUnique();

        builder
            .Property(product => product.Title)
            .HasColumnName("title");
    }
}

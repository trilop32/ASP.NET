using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportPit.Models;

namespace SportPit.Data.EntityTypeConfigurations;

public class CartsConfiguration : IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> builder)
    {
        builder
            .ToTable("carts");

        builder
            .HasKey(cart => cart.Id);

        builder
            .HasIndex(cart => cart.Id)
            .IsUnique();

        builder
            .Property(cart => cart.Price)
            .HasColumnName("price");

        builder
           .Property(cart => cart.DatePurchase)
           .HasColumnName("date_purchase");
    }
}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SportPit.Extensions;
using SportPit.Models;
namespace SportPit.Data;

public class ApplicationContext(DbContextOptions<ApplicationContext> options) : IdentityDbContext(options)
{
    public required DbSet<Product> Products { get; set; }
    public required DbSet<Cart> Carts { get; set; }
    public required new DbSet<User> Users { get; set; }
    public required DbSet<Category> Category { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyAllConfigurations();
        base.OnModelCreating(modelBuilder);
    }
}
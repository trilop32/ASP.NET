using Teledok.Domain;
using Microsoft.EntityFrameworkCore;
using Teledok.Persistence.Extensions;

namespace Teledok.Persistence;

public class TeledokDbContext(DbContextOptions<TeledokDbContext> options) : DbContext(options)
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<Founder> Founders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyAllConfigurations();
        base.OnModelCreating(modelBuilder);
    }
}
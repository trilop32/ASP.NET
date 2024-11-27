using Microsoft.EntityFrameworkCore;
using TheUltimateGamingPlatform.Model;

namespace TheUltimateGamingPlatform.Database;

public class TheUltimateGamingPlatformContext(DbContextOptions<TheUltimateGamingPlatformContext> options) : DbContext(options)
{
    public DbSet<Game> Games { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<GameContent> GameContents { get; set; }
    public DbSet<SystemRequirement> SystemRequirements { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<User> Users { get; set; }
}
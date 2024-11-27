using TheUltimateGamingPlatform.Database.Repository.Interfaces;
using TheUltimateGamingPlatform.Model;

namespace TheUltimateGamingPlatform.Database.Repository;

public class RepositoryCart(TheUltimateGamingPlatformContext context) : IRepositoryCart
{
    public async Task AddAsync(Cart cart)
    {
        await context.Carts.AddAsync(cart);
        await context.SaveChangesAsync();
    }
}

using Microsoft.EntityFrameworkCore;
using TheUltimateGamingPlatform.Database.Repository.Interfaces;
using TheUltimateGamingPlatform.Model;

namespace TheUltimateGamingPlatform.Database.Repository;

public class RepositoryUser(TheUltimateGamingPlatformContext context) : IRepositoryUser
{
    public async Task AddGameWishListAsync(int idGame, int idUser)
    {
        var game = await context.Games
            .Include(game => game.Users)
            .SingleAsync(game => game.Id == idGame);

        var user = await context.Users
            .Include(user => user.Games)
            .SingleAsync(user => user.Id == idUser);

        game.Users.Add(user);
        user.Games.Add(game);

        await context.SaveChangesAsync();
    }

    public async Task<User> GetByIdAsync(int id) =>
        await context.Users.SingleAsync(user => user.Id == id);

    public async Task<List<Game>> GetGamesWishListAsync(int id)
    {
        var user = await context.Users
            .Include(user => user.Games)
            .SingleAsync(user => user.Id == id);

        return user.Games;
    }

    public async Task<bool> IsPurchasedGameAsync(int idGame, int idUser) =>
        await context.Carts
            .Include(cart => cart.User)
            .Include(cart => cart.Games)
            .Where(cart => cart.Games
                            .Select(game => game.Id)
                            .Contains(idGame))
            .Where(cart => cart.User.Id == idUser)
            .AnyAsync();
}
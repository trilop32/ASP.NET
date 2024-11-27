using Microsoft.EntityFrameworkCore;
using TheUltimateGamingPlatform.Model;
using TheUltimateGamingPlatform.Database.Repository.Interfaces;
using System.Linq;

namespace TheUltimateGamingPlatform.Database.Repository;

public class RepositoryGame(TheUltimateGamingPlatformContext context) : IRepositoryGame
{
    public async Task<List<Game>> GetAllAsync() =>
        await context.Games.ToListAsync();

    public async Task<Game> GetByIdAsync(int id) =>
        await context.Games.SingleAsync(game => game.Id == id);

    public async Task<Game> GetDetailsAsync(int id) =>
        await context.Games
            .Include(game => game.Genres)
            .Include(game => game.GameContents)
            .Include(game => game.MinimumSystemRequirement)
            .Include(game => game.RecommendedSystemRequirement)
            .SingleAsync(game => game.Id == id);

    public async Task<List<Game>> GetGamesByListId(List<int> listId) =>
        await context.Games.Where(game => listId.Contains(game.Id)).ToListAsync();

    public async Task<List<Game>> GetGamesByUserId(int id)
    {
        var games = new List<Game>();

        var listGames = await context.Carts
            .Include(cart => cart.User)
            .Include(cart => cart.Games)
            .Where(cart => cart.User.Id == 1)
            .Select(cart => cart.Games)
            .ToListAsync();

        foreach (var game in listGames)
        {
            games.AddRange(game);
        }

        return games;
    }
}
using Microsoft.EntityFrameworkCore;
using TheUltimateGamingPlatform.Model;
using TheUltimateGamingPlatform.Database.Repository.Interfaces;

namespace TheUltimateGamingPlatform.Database.Repository;

public class RepositoryGame(TheUltimateGamingPlatformContext context) : IRepositoryGame
{
    public async Task<List<Game>> GetGamesAsync() =>
        await context.Games.ToListAsync();
}

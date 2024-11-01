using TheUltimateGamingPlatform.Model;

namespace TheUltimateGamingPlatform.Database.Repository.Interfaces;

public interface IRepositoryGame
{
    public Task<List<Game>> GetGamesAsync();
}
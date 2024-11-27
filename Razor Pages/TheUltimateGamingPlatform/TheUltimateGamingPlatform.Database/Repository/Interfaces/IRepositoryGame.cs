using TheUltimateGamingPlatform.Model;

namespace TheUltimateGamingPlatform.Database.Repository.Interfaces;

public interface IRepositoryGame
{
    Task<List<Game>> GetAllAsync();
    Task<Game> GetDetailsAsync(int id);
    Task<Game> GetByIdAsync(int id);
    Task<List<Game>> GetGamesByUserId(int id);
    Task<List<Game>> GetGamesByListId(List<int> listId);
}
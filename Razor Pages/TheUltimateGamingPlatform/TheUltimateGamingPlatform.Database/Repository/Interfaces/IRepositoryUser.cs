using TheUltimateGamingPlatform.Model;

namespace TheUltimateGamingPlatform.Database.Repository.Interfaces;

public interface IRepositoryUser
{
    Task AddGameWishListAsync(int idGame, int idUser);
    Task<bool> IsPurchasedGameAsync(int idGame, int idUser);
    Task<User> GetByIdAsync(int id);
    Task<List<Game>> GetGamesWishListAsync(int id);
}
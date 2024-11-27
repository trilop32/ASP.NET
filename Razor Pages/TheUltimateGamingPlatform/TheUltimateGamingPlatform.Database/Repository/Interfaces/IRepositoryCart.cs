using TheUltimateGamingPlatform.Model;

namespace TheUltimateGamingPlatform.Database.Repository.Interfaces;

public interface IRepositoryCart
{
    Task AddAsync(Cart cart);
}

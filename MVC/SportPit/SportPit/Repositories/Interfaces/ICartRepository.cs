using SportPit.Models;

namespace SportPit.Repositories.Interfaces;

public interface ICartRepository
{
    Task AddAsync(List<Product> products, User user, DateOnly date, decimal sum);
    Task<List<Cart>> GetCartsDetailsByUserAsync(User user);
}

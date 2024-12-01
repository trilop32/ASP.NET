using SportPit.Models;

namespace SportPit.Repositories.Interfaces;

public interface IProductRepository
{
    Task<Product> GetByIdAsync(int id);
    Task<List<Product>> GetAllAsync();
    Task<List<Product>> GetProductsByListIdAsync(List<int> listId);
    Task AddAsync(Product product);
    Task UpdateAsync(Product product);
    Task RemoveAsync(int id);
    Task<List<Product>> FindProductsAsync(string titleProduct, string selectedCategory, int countSkip, int countTake);
}
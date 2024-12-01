using Microsoft.EntityFrameworkCore;
using SportPit.Data;
using SportPit.Models;
using SportPit.Repositories.Interfaces;

namespace SportPit.Repositories;

public class ProductRepository(ApplicationContext context) : IProductRepository
{
    public async Task AddAsync(Product product)
    {
        await context.AddAsync(product);
        await context.SaveChangesAsync();
    }

    public Task<List<Product>> GetAllAsync() =>
        context.Products.ToListAsync();

    public Task<Product> GetByIdAsync(int id) =>
        context.Products.SingleAsync(product => product.Id == id);

    public async Task<List<Product>> GetProductsByListIdAsync(List<int> listId) => 
        await context.Products.Where(x => listId.Contains(x.Id)).ToListAsync();

    public async Task UpdateAsync(Product product)
    {
        try
        {
            context.Update(product);
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await IsExistsAsync(product.Id))
            {
                throw new Exception("Not Found");
            }
            else
            {
                throw;
            }
        }
    }

    public async Task<bool> IsExistsAsync(int id) =>
        await context.Products.AnyAsync(product => product.Id == id);

    public async Task RemoveAsync(int id)
    {
        var product = await GetByIdAsync(id);
        context.Products.Remove(product);
        await context.SaveChangesAsync();
    }

    public Task<List<Product>> FindProductsAsync(string titleProduct, string selectedCategory, int countSkip, int countTake)
    {
        var products = from m in context.Products
                       select m;

        if (!string.IsNullOrEmpty(titleProduct))
        {
            products = products.Where(s => s.Title!.ToUpper().Contains(titleProduct.ToUpper()));
        }

        if (!string.IsNullOrEmpty(selectedCategory))
        {
            products = products
                .Include(product => product.Category)
                .Where(product => product.Category.Title == selectedCategory);
        }

        return products.Skip(countSkip).Take(countTake).ToListAsync();
    }
}
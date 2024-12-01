using Microsoft.EntityFrameworkCore;
using SportPit.Data;
using SportPit.Models;
using SportPit.Repositories.Interfaces;

namespace SportPit.Repositories;

public class CartRepository(ApplicationContext context) : ICartRepository
{
    public async Task AddAsync(List<Product> products, User user, DateOnly date, decimal sum)
    {
        var cart = new Cart
        {
            Products = products,
            Price = sum,
            DatePurchase = date,
            User = user
        };

        await context.AddAsync(cart);
        await context.SaveChangesAsync();
    }

    public async Task<List<Cart>> GetCartsDetailsByUserAsync(User user) =>
        await context.Carts
            .Include(cart => cart.Products)
            .Where(cart => cart.User == user)
            .ToListAsync();
}
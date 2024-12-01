using Microsoft.EntityFrameworkCore;
using SportPit.Data;
using SportPit.Repositories.Interfaces;

namespace SportPit.Repositories;

public class CategoryRepository(ApplicationContext context) : ICategoryRepository
{
    public async Task<List<string>> GetTitleCategoriesAsync() =>
        await context.Category.Select(category => category.Title).ToListAsync();
}
namespace SportPit.Repositories.Interfaces;

public interface ICategoryRepository
{
    Task<List<string>> GetTitleCategoriesAsync();
}
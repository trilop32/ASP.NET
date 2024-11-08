using ConsoleApp1.Model;
namespace ConsoleApp1.Database.Repositories.Interfaces;

public class IRepositoryMovie
{
    Task<List<Movie>> GetAll();
    Task<Movie> GetById(int id);
}

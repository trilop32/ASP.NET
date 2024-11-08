using ConsoleApp1.Database.Repositories.Interfaces;
using ConsoleApp1.Model;
namespace ConsoleApp1.Database.Repositories;

public class RepositoryMovieAdo:IRepositoryMovie
{
    public Task<List<Movie>> GetAll()
    {
        return null;
    }
    public Task<Movie> GetById(int id)
    {
        return null;
    }
}

using ConsoleApp1.Database.Repositories.Interfaces;
using ConsoleApp1.Model;
using Microsoft.EntityFrameworkCore;
namespace ConsoleApp1.Database.Repositories;

public class RepositoryMovieORM : IRepositoryMovie
{
    private readonly ApplicationContext applicationContext=new();
    public async Task<List<Movie>> GetAll()
    {
        return await applicationContext.Movies.ToListAsync();
    }
    public async Task<Movie> GetById(int id)
    {
        return await applicationContext.Movies.SingleAsync(movie=>movie.Id==id);
    }
}

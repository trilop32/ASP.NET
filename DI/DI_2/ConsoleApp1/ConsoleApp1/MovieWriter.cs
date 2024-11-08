using ConsoleApp1.Database;
using ConsoleApp1.Database.Repositories.Interfaces;

namespace ConsoleApp1;

public class MovieWriter(IRepositoryMovie messageWrite,IRepositoryMovie repositoryMovies)
{
    public async Task ShowAllMovies()
    {
        var movies = await repositoryMovies.GetAll();
        foreach (var movie in movies)
        {
            messageWrite.Write(movie.ToString());
        }
    }
    public async Task ShowMovieById(int id)
    {
        var movie = await repositoryMovies.GetById(id);
        messageWrite.Write(movie.ToString());
        
    }
}

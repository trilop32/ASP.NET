using ConsoleApp1.Database.Repositories.Interfaces;
using ConsoleApp1.Model;
using Microsoft.Data.SqlClient;
using System.Data;
namespace ConsoleApp1.Database.Repositories;
public class RepositoryMovieAdo : IRepositoryMovie
{
    private readonly string cs = "Data Source=DESKTOP-UR671I8\\SQLEXPRESS01;Initial Catalog=Movies;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";
    public async Task<List<Movie>> GetAll()
    {
        var movies = new List<Movie>();

        using (var connection = new SqlConnection(cs))
        {
            await connection.OpenAsync();
            using (var command = new SqlCommand(
                "Select Id, Title, Description, DateRelease " + "From Movies", connection))
            {
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var movie = new Movie
                        {
                            Id = reader.GetInt32(0),
                            Title = reader.GetString(1),
                            Description = reader.GetString(2),
                            DateRelease = DateOnly.FromDateTime(reader.GetDateTime(3))
                        };
                        movies.Add(movie);
                    }
                }
            }
        }
        return movies;
    }
    public async Task<Movie> GetById(int id)
    {
        Movie movie = null;

        using (var connection = new SqlConnection(cs))
        {
            await connection.OpenAsync();
            using (var command = new SqlCommand(
                "Select Id, Title, Description, DateRelease " + "From Movies " + "Where Id = @Id", connection))
            {
                command.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = id });
                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        movie = new Movie
                        {
                            Id = reader.GetInt32(0),
                            Title = reader.GetString(1),
                            Description = reader.GetString(2),
                            DateRelease = DateOnly.FromDateTime(reader.GetDateTime(3))
                        };
                    }
                }
            }
        }
        return movie;
    }
}
using Microsoft.EntityFrameworkCore;
namespace ConsoleApp1;

public class RepositoryORM(ApplicationContext applicationContext)
{
    public async List<Movie> GetAll()
    {
        return await applicationContext.Movies.ToListAsync();
    }
}

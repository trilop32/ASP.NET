using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1;

public class ApplicationContext:DbContext
{
    public DbSet<Movie> Movies { get; set; }
    protected override void OnConfiguring(DbContextOptionsBilder optionsBilder)
    {
        optionsBilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=helloappdb;Trusted_Connection=True;");
    }
}

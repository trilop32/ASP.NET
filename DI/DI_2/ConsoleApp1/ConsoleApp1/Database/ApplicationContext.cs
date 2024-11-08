using ConsoleApp1.Model;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1.Database;

public class ApplicationContext : DbContext
{
    public DbSet<Movie> Movies { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBilder)
    {
        optionsBilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=helloappdb;Trusted_Connection=True;");
    }
}

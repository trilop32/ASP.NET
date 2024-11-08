using ConsoleApp1;
using ConsoleApp1.Database.Repositories.Interfaces;
using ConsoleApp1.Messages;
using ConsoleApp1.Messages.Interfaces;
using Microsoft.Extensions.DependencyInjection;
/*
var movieWriter=new MovieWriter(new RepositoryMovieAdo(), new RepositoryMovieORM());
await movieWriter.ShowAllMovies();
await movieWriter.ShowMovieById(3);
*/
/*
IServiceCollection services=new ServiceCollection();
services.AddScoped<IMessageWrite,ConsoleMessageWrite>();
using var serviceProvider = services.BuildServiceProvider();
using (IServiceScope scope = serviceProvider.CreateScope())
{

    IMessageWrite messageWrite1 = scope.ServiceProvider.GetService<IMessageWrite>();
    IMessageWrite messageWrite2 = scope.ServiceProvider.GetService<IMessageWrite>();
    Console.WriteLine(messageWrite1.rand);
    Console.WriteLine(messageWrite2.rand);
}
using (IServiceScope scope = serviceProvider.CreateScope())
{

    IMessageWrite messageWrite1 = scope.ServiceProvider.GetService<IMessageWrite>();
    IMessageWrite messageWrite2 = scope.ServiceProvider.GetService<IMessageWrite>();
    Console.WriteLine(messageWrite1.rand);
    Console.WriteLine(messageWrite2.rand);
}*/
IServiceCollection services = new ServiceCollection();
services.AddScoped<IMessageWrite, ConsoleMessageWrite>();
services.AddTransient<IRepositoryMovie, IRepositoryMovie>();
services.AddTransient<MovieWriter>();
using var serviceProvider=services.BuildServiceProvider();
var movieWriter=serviceProvider.GetRequiredService<MovieWriter>();
await movieWriter.ShowMovieById(3);
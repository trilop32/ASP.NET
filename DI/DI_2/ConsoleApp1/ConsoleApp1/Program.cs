using ConsoleApp1.Messages;
using ConsoleApp1.Messages.Interfaces;
using Microsoft.Extensions.DependencyInjection;

//var movieWriter=new MovieWriter(new RepositoryMovieAdo(), new RepositoryMovieORM());
//await movieWriter.ShowAllMovies();
//await movieWriter.ShowMovieById(3);

IServiceCollection services=new ServiceCollection();
services.AddTransient<IMessageWrite,ConsoleMessageWrite>();
using var serviceProvider=services.BuildServiceProvider();
IMessageWrite? messageWrite1 = serviceProvider.GetService<IMessageWrite>();
IMessageWrite? messageWrite2 = serviceProvider.GetService<IMessageWrite>();
Console.WriteLine(messageWrite1.rand);
Console.WriteLine(messageWrite2.rand);
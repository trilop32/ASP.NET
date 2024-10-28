using DI;
using MessageProject;
using Microsoft.Extensions.DependencyInjection;
var game = new Game
{
    Title ="Марио",
    Genre = "платформер",
    DataRelease = new DateOnly(1981,9,13),
    Publisher="Sony",
    Multiplayear=false,
};
//var gameStoreViewModel=new GameStoreViewModel(game,new ValidationMessageWrite("qwerty","12345678",new MessageBoxWrite()));
//gameStoreViewModel.Show();
//Console.ReadLine();
var services= new ServiceCollection();
services.AddTransient<IMessageWrite,MessageBoxWrite>();
services.AddTransient<GameStoreViewModel>();
using var serviceProvider= services.BuildServiceProvider();
var gameStoreViewModel = serviceProvider.GetService<GameStoreViewModel>();
gameStoreViewModel.Show(game);
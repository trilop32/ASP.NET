using Microsoft.EntityFrameworkCore;
using TheUltimateGamingPlatform.Database;
using TheUltimateGamingPlatform.Database.Repository;
using TheUltimateGamingPlatform.Database.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddTransient<IRepositoryGame, RepositoryGame>();

string connection = builder.Configuration.GetConnectionString("TheUltimateGamingPlatformConnection");
// добавляем контекст ApplicationContext в качестве сервиса в приложение
builder.Services.AddDbContext<TheUltimateGamingPlatformContext>(options =>
    options.UseSqlServer(connection));

var app = builder.Build();

app.MapRazorPages();
app.Run();

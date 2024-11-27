using Microsoft.EntityFrameworkCore;
using TheUltimateGamingPlatform.Database;
using TheUltimateGamingPlatform.Database.Repository;
using TheUltimateGamingPlatform.Database.Repository.Interfaces;
using TheUltimateGamingPlatform.Web.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();

builder.Services.AddSingleton<CartGameRepository>();
builder.Services.AddTransient<IRepositoryCart, RepositoryCart>();

builder.Services.AddTransient<IRepositoryUser, RepositoryUser>();
builder.Services.AddTransient<IRepositoryGame, RepositoryGame>();

string connection = builder.Configuration.GetConnectionString("TheUltimateGamingPlatformConnection");
// ��������� �������� ApplicationContext � �������� ������� � ����������
builder.Services.AddDbContext<TheUltimateGamingPlatformContext>(options =>
    options.UseSqlServer(connection));

var app = builder.Build();

app.MapRazorPages();
app.Run();


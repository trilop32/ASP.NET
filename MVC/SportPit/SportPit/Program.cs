using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SportPit;
using SportPit.Data;
using SportPit.Models;
using SportPit.Repositories;
using SportPit.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

string connection = builder.Configuration.GetConnectionString("SportPitConnectionDB");
// добавляем контекст ApplicationContext в качестве сервиса в приложение
builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseNpgsql(connection));
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services
    .AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationContext>();
builder.Services.AddMemoryCache();
builder.Services.AddSession();
builder.Services
    .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

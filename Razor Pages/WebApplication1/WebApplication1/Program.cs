var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
//Конфигурация зависимости
var app = builder.Build();
//Конфигурируется запросы и ответыы (конечная точка / endpoint)
//app.UseStaticFiles();
//app.Map("/", () => "Hello World");
//app.MapGet("/", () => "Hello World!");
app.MapRazorPages();
app.Run();

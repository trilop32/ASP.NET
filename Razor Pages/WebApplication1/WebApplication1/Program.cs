var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
//������������ �����������
var app = builder.Build();
//��������������� ������� � ������� (�������� ����� / endpoint)
//app.UseStaticFiles();
//app.Map("/", () => "Hello World");
//app.MapGet("/", () => "Hello World!");
app.MapRazorPages();
app.Run();

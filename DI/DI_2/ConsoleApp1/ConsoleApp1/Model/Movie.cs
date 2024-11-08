namespace ConsoleApp1.Model;

internal class Movie
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }// ? - даёт возможность содержать null
    public DateOnly DateRelease { get; set; }
    public override string ToString()
    {
        return $"Название: {Title}\n Описание: {Description}\n Дата релиза: {DateRelease.ToString("D")}";
    }
}


namespace ConsoleApp1;

internal class Movie
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }// ? - даёт возможность содержать null
    public DateOnly DateRelease { get; set; }

}

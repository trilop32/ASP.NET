namespace TheUltimateGamingPlatform.Model;

public class User
{
    public int Id { get; set; }
    public required string UserName { get; set; }
    public required List<Game> Games { get; set; }
}
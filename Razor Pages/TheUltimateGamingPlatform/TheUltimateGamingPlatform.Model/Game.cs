namespace TheUltimateGamingPlatform.Model;

public class Game
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required decimal Price { get; set; }
    public required string PreviewImg { set; get; }
    public required List<Genre> Genres { get; set; }
    public required List<Cart> Carts { get; set; }
    public required List<GameContent> GameContents { get; set; }
    public required SystemRequirement MinimumSystemRequirement { get; set; }
    public required SystemRequirement? RecommendedSystemRequirement { get; set; }
    public required List<User> Users { get; set; }
}

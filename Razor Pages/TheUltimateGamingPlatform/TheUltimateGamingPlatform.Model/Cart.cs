namespace TheUltimateGamingPlatform.Model;

public class Cart
{
    public int Id { get; set; }
    public required DateOnly DatePurchase { get; set; }
    public required decimal Sum { get; set; }
    public required User User { get; set; }
    public required List<Game> Games { get; set; }
}
namespace SportPit.Models;

public class Cart
{
    public int Id { get; set; }
    public required decimal Price { get; set; }
    public required DateOnly DatePurchase { get; set; }
    public required List<Product> Products { get; set; }
    public required User User { get; set; }
}
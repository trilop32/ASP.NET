namespace SportPit.Models;

public class Product
{
    public int Id { get; set; } 
    public required string Title { get; set; }
    public required string Img { get; set; }
    public required decimal Price { get; set; }
    public required string Description { get; set; }
    public required Category? Category { get; set; }
    public required List<Cart>? Carts { get; set; }
}
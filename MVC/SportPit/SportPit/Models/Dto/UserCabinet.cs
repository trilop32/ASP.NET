namespace SportPit.Models.Dto;

public struct UserCabinet
{
    public required User User { get; set; }
    public required List<Cart> Carts { get; set; }
}
namespace SportPit.Models.Dto;

public struct CartDto
{
    public decimal Price { get; init; }
    public Dictionary<ProductCartDto, int> Products { get; init; }
}
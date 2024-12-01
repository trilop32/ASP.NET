namespace SportPit.Models.Dto;

public struct ProductCartDto
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Img { get; set; }
    public required decimal Price { get; set; }
    public required string Description { get; set; }
}

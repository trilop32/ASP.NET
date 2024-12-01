using Microsoft.AspNetCore.Mvc.Rendering;
using SportPit.Core;

namespace SportPit.Models;

public class ProductsViewModel
{
    public required List<Product> Products { get; set; }
    public required SelectList Categories { get; set; }
    public required string? TitleProduct { get; set; }
    public required string? SelectedCategory { get; set; }
    public required PageViewModel PageViewModel { get; set; }
    public required Filtered? Filtered { get; set; }
}

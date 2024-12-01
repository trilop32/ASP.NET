using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportPit.Core;
using SportPit.Data;
using SportPit.Models;
using SportPit.Models.Dto;
using SportPit.Repositories.Interfaces;
using System.Diagnostics;

namespace SportPit.Controllers;

public class HomeController(
    ApplicationContext applicationContext,
    IProductRepository productRepository, 
    IOrderRepository orderRepository,
    ICategoryRepository categoryRepository) : Controller
{
    private const int pageSize = 10;
    public async Task<IActionResult> Index(
        string titleProduct, 
        string selectedCategory, 
        Filtered? filtered, 
        int page = 1)
    {
        bool isFiltering = false;
        int count = 0;

        var products = from m in applicationContext.Products
                       select m;

        if (!string.IsNullOrEmpty(titleProduct))
        {
            isFiltering = true;
            products = products.Where(s => s.Title!.ToUpper().Contains(titleProduct.ToUpper()));
        }

        if (!string.IsNullOrEmpty(selectedCategory))
        {
            isFiltering = true;
            products = products
                .Include(product => product.Category)
                .Where(product => product.Category.Title == selectedCategory);
        }

        if (isFiltering)
        {
            count = products.Count();
        }
        else
        {
            count = await applicationContext.Products.CountAsync();
        }

        var resProducts = products.Skip((page - 1) * pageSize).Take(pageSize);

        var titleCategories = await categoryRepository.GetTitleCategoriesAsync();

        if (filtered == Filtered.PriceAsc)
        {
            resProducts = resProducts.OrderByDescending(product => product.Price);
        }

        if (filtered == Filtered.PriceDesc)
        {
            resProducts = resProducts.OrderBy(product => product.Price);
        }

        var productsViewModel = new ProductsViewModel
        {
            TitleProduct = titleProduct,
            SelectedCategory = selectedCategory,
            Categories = new(titleCategories),
            Products = await resProducts.ToListAsync(),
            Filtered = filtered,
            PageViewModel = new PageViewModel(count, page, pageSize)
        };

        return View(productsViewModel);
    }

    public async Task<IActionResult> Details(int id)
    {
        var product = await productRepository.GetByIdAsync(id);

        return View(product);
    }

    public IActionResult AddCart(
        int id, 
        string title, 
        string description, 
        string img, 
        decimal price)
    {
        var productCartDTO = new ProductCartDto
        {
            Id = id,
            Price = price,
            Title = title,
            Description = description,
            Img = img
        };

        orderRepository.Add(productCartDTO);

        return RedirectToAction("Index", "Cart");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

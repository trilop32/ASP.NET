using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SportPit.Core;
using SportPit.Migrations;
using SportPit.Models;
using SportPit.Models.Dto;
using SportPit.Repositories.Interfaces;

namespace SportPit.Controllers;

public class CartController(
    IOrderRepository orderRepository,
    ICartRepository cartRepository,
    IProductRepository productRepository,
    IUserRepository userRepository,
    IHttpContextAccessor httpContextAccessor,
    UserManager<User> userManager) : Controller
{
    public IActionResult Index()
    {
        var cartDto = new CartDto
        {
            Price = orderRepository.Sum,
            Products = orderRepository.CountProductsByProductId
        };

        return View(cartDto);
    }

    public async Task<IActionResult> CreateOrder()
    {
        if ((bool)!httpContextAccessor.HttpContext?.User.Identity.IsAuthenticated)
        {
            return RedirectToAction("Login", "Account");
        }

        var userName = httpContextAccessor.HttpContext?.User.Identity.Name;
        var user = await userManager.FindByNameAsync(userName);
        var products = await productRepository
            .GetProductsByListIdAsync(orderRepository.CountProductsByProductId.Keys.Select(x => x.Id).ToList());

        await cartRepository.AddAsync(products, user, DateOnly.FromDateTime(DateTime.Now), orderRepository.Sum);

        orderRepository.Clear();

        HomeController home;

        return RedirectToAction(
            nameof(home.Index),
            ControllerName.GetName(nameof(HomeController))
            );
    }

    public IActionResult SubCountProduct(int idProduct)
    {
        var product = orderRepository.CountProductsByProductId.Keys.Single(x => x.Id == idProduct);
        orderRepository.Remove(product);
       
        CartController cart;

        return RedirectToAction(
            nameof(cart.Index),
            ControllerName.GetName(nameof(CartController))
            );
    }

    public IActionResult AddCountProduct(int idProduct)
    {
        var product = orderRepository.CountProductsByProductId.Keys.Single(x => x.Id == idProduct);
        orderRepository.Add(product);

        CartController cart;

        return RedirectToAction(
            nameof(cart.Index),
            ControllerName.GetName(nameof(CartController))
            );
    }
}
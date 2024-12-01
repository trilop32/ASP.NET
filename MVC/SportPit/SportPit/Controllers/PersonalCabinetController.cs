using Microsoft.AspNetCore.Mvc;
using SportPit.Models.Dto;
using SportPit.Repositories.Interfaces;

namespace SportPit.Controllers;

public class PersonalCabinetController(
    IUserRepository userRepository, 
    ICartRepository cartRepository) : Controller
{
    public async Task<IActionResult> Index()
    {
        var user = await userRepository.GetUserByIdAsync("1");
        var carts = await cartRepository.GetCartsDetailsByUserAsync(user);

        var userCabinet = new UserCabinet
        {
            User = user,
            Carts = carts
        };

        return View(userCabinet);
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheUltimateGamingPlatform.Database.Repository.Interfaces;
using TheUltimateGamingPlatform.Model;
using TheUltimateGamingPlatform.Web.Repositories;

namespace TheUltimateGamingPlatform.Web.Pages;

public class CartModel(
    IRepositoryCart repositoryCart,
    IRepositoryUser repositoryUser,
    IRepositoryGame repositoryGame, 
    CartGameRepository cartGameRepository) : PageModel
{
    public List<Game>? Games { get; set; }
    public decimal SumProduct { get; set; }

    private User? user;
    public async Task OnGetAsync()
    {
        user = await repositoryUser.GetByIdAsync(1);
        Games = cartGameRepository.Games;
        SumProduct = cartGameRepository.Games.Sum(game => game.Price);
    }

    public void OnPostDeleteGame(int id)
    {
        var game = cartGameRepository.Games.Single(game => game.Id == id);
        cartGameRepository.Games.Remove(game);
    }

    public async Task<IActionResult> OnPostCreateOrder()
    {
        var user = await repositoryUser.GetByIdAsync(1);
        var listId = cartGameRepository.Games.Select(x => x.Id).ToList();
        var games = await repositoryGame.GetGamesByListId(listId);
        
        var cart = new Cart
        {
            DatePurchase = DateOnly.FromDateTime(DateTime.Now),
            Sum = cartGameRepository.Games.Sum(game => game.Price),
            User = user,
            Games = games
        };

        await repositoryCart.AddAsync(cart);

        cartGameRepository.Games.Clear();
        
        return RedirectToPage("/Index");
    }
}
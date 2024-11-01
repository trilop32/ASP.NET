using Microsoft.AspNetCore.Mvc.RazorPages;
using TheUltimateGamingPlatform.Database.Repository.Interfaces;
using TheUltimateGamingPlatform.Model;

namespace TheUltimateGamingPlatform.Web.Pages;

public class IndexModel(IRepositoryGame repositoryGame) : PageModel
{
    public List<Game> Games { get; set; } = [];
    public async Task OnGet()
    {
        Games = await repositoryGame.GetGamesAsync();
    }
}
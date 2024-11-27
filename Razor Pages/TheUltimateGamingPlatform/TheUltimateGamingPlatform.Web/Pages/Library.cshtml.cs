using Microsoft.AspNetCore.Mvc.RazorPages;
using TheUltimateGamingPlatform.Database.Repository.Interfaces;
using TheUltimateGamingPlatform.Model;

namespace TheUltimateGamingPlatform.Web.Pages;

public class LibraryModel(IRepositoryGame repositoryGame) : PageModel
{
    public List<Game> Games { get; set; } = [];

    public async Task OnGetAsync()
    {
        Games = await repositoryGame.GetGamesByUserId(1);
    }
}
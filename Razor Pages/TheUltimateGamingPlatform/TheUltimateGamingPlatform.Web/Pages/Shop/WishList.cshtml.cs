using Microsoft.AspNetCore.Mvc.RazorPages;
using TheUltimateGamingPlatform.Database.Repository.Interfaces;
using TheUltimateGamingPlatform.Model;

namespace TheUltimateGamingPlatform.Web.Pages.Shop;

public class WishListModel(IRepositoryUser repositoryUser) : PageModel
{
    public List<Game>? Games { get; set; }

    public async Task OnGetAsync()
    {
        Games = await repositoryUser.GetGamesWishListAsync(1);
    }
}
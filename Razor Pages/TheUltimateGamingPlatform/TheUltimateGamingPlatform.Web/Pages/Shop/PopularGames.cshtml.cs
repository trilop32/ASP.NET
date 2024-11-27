using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TheUltimateGamingPlatform.Database;
using TheUltimateGamingPlatform.Model;

namespace TheUltimateGamingPlatform.Web.Pages.Shop;

public class PopularGamesModel(TheUltimateGamingPlatformContext context) : PageModel
{
    public List<Game>? Games { get; set;  }
    public async Task OnGetAsync()
    {
        var dictionary = new Dictionary<Game, int>();

        var carts = await context.Carts.Include(x => x.Games).Where(
            x => x.DatePurchase >= DateOnly.FromDateTime(DateTime.Now.AddMonths(-1))).ToListAsync();

        foreach (var car in carts)
        {
            foreach (var game in car.Games)
            {
                if (!dictionary.TryGetValue(game, out int value))
                {
                    dictionary.Add(game, 1);
                }
                else
                {
                    dictionary[game] = ++value;
                }
            }
        }

        var sortedDict = (from entry in dictionary orderby entry.Value ascending select entry).ToDictionary();

        Games = new List<Game>(sortedDict.Keys);
    }
}
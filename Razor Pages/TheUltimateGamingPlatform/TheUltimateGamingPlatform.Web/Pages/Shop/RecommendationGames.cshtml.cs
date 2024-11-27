using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TheUltimateGamingPlatform.Database;
using TheUltimateGamingPlatform.Model;

namespace TheUltimateGamingPlatform.Web.Pages.Shop;

public class RecommendationGamesModel(TheUltimateGamingPlatformContext context) : PageModel
{
    public HashSet<Game>? Games { get; set; }
    public async Task OnGetAsync()
    {
        var resultGames = new HashSet<Game>();
        var idGenres = new HashSet<int>();

        var user = await context.Users
            .Include(x => x.Games)
            .ThenInclude(x => x.Genres)
            .SingleAsync(x => x.Id == 1);

        var carts = await context.Carts
            .Include(x => x.Games)
            .ThenInclude(x => x.Genres)
            .Include(x => x.User)
            .Where(x => x.User.Id == 1)
            .ToListAsync();

        foreach ( var cart in carts )
        {
            foreach (var game in cart.Games)
            {
                foreach (var genre in game.Genres)
                {
                    if (!idGenres.Contains(genre.Id))
                    {
                        idGenres.Add(genre.Id);
                    }
                }
            }
        }

        foreach (var game in user.Games)
        {
            var listId = game.Genres.Select(x => x.Id);

            foreach (var id in listId)
            {
                if (listId.Contains(id))
                {
                    idGenres.Add(id);
                }   
            }
        }


        var games = context.Games.Include(x => x.Genres);
        var resGames = new HashSet<Game>();
        foreach (var game in games)
        {
            foreach (var genre in game.Genres)
            {
                if (idGenres.Contains(genre.Id))
                {
                    resGames.Add(game);
                }
            }
        }

        Games = resGames;
    }
}
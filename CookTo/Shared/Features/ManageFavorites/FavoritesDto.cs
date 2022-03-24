namespace CookTo.Shared.Features.ManageFavorites;

public class FavoritesDto
{
    public string Username { get; set; }

    public List<string>? Favorites { get; set; }
}
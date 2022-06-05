namespace CookTo.Shared.Features.ManageFavorites;

public class FavoritesDto
{
    public string Username { get; set; }   = string.Empty;

    public List<string>? Favorites { get; set; }
}
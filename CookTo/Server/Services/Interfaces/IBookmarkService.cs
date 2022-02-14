using CookTo.Server.Documents.FavoritesDocument;

namespace CookTo.Server.Services.Interfaces;

public interface IBookmarksService : IBaseService<FavoriteRecipes>
{
    Task<FavoriteRecipes> GetByUserIdAsync(string id, CancellationToken token);
}

using CookTo.Server.Documents.FavoritesDocument;

namespace CookTo.Server.Services.Interfaces;

public interface IFavoriteService : IBaseService<FavoriteRecipes>
{
    Task<FavoriteRecipes> GetByUserIdAsync(string id, CancellationToken token);
}

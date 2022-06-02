using CookTo.Server.Documents;

namespace CookTo.Server.Services.Interfaces;

public interface IFavoriteService : IBaseService<FavoriteRecipeDocument>
{
    Task<FavoriteRecipeDocument> GetByUserIdAsync(string id, CancellationToken token);
}

using CookTo.Server.Documents.FavoritesDocument;
using CookTo.Server.Services.Interfaces;

namespace CookTo.Server.Services;

public class FavoritesService : BaseService<FavoriteRecipes>, IFavoriteService
{
    public FavoritesService(ICookToDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<FavoriteRecipes> GetByUserIdAsync(string id, CancellationToken token) => await dbCollection.Find(
        e => e.Username.Equals(id))
        .FirstOrDefaultAsync();
}

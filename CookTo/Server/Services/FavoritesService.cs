using CookTo.Server.Documents;
using CookTo.Server.Services.Interfaces;

namespace CookTo.Server.Services;

public class FavoritesService : BaseService<FavoriteRecipeDocument>, IFavoriteService
{
    public FavoritesService(ICookToDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<FavoriteRecipeDocument> GetByUserIdAsync(string id, CancellationToken token) => await dbCollection.Find(
        e => e.Username.Equals(id))
        .FirstOrDefaultAsync();
}

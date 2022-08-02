using CookTo.Server.Modules;
using CookTo.Server.Modules.RecipeHighlighted.Core;
using CookTo.Server.Modules.Recipes.Services;

namespace CookTo.Server.Modules.RecipeHighlighted.Services;

public class RecipeHighlightedService : BaseService<HighlightedRecipeDocument>, IRecipeHighlightedService
{
    public RecipeHighlightedService(ICookToDbContext dbContext) : base(dbContext)
    {
    }
    public async Task<HighlightedRecipeDocument> GetAsync(CancellationToken token) => await DbCollection.Find(e => true)
        .FirstOrDefaultAsync();
}



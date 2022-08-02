using CookTo.Server.Modules;
using CookTo.Server.Modules.Recipes.Core;

namespace CookTo.Server.Modules.Recipes.Services;

public class RecipeService : BaseService<RecipeDocument>, IRecipeService
{
    public RecipeService(ICookToDbContext dbContext) : base(dbContext)
    {
    }
}



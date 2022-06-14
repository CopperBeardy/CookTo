using CookTo.Server.Modules;
using CookTo.Server.Modules.Recipes.Core;

namespace CookTo.Server.Modules.Recipes.Services;

public interface IRecipeService : IBaseService<RecipeDocument>
{
    Task<List<RecipeDocument>> GetAllByTerm(string term, CancellationToken token);

    Task<List<RecipeDocument>> GetByLimit(int limit, CancellationToken token);
}

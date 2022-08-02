using CookTo.Server.Modules;
using CookTo.Server.Modules.RecipeHighlighted.Core;

namespace CookTo.Server.Modules.RecipeHighlighted.Services;

public interface IRecipeHighlightedService : IBaseService<HighlightedRecipeDocument>
{
    Task<HighlightedRecipeDocument> GetAsync(CancellationToken token);
}

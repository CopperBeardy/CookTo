using CookTo.Server.Modules.Recipes.Services;

namespace CookTo.Server.Modules.Images.Handlers;

public class CommonParameters
{
    public IRecipeService RecipeService { get; set; }

    public CancellationToken CancellationToken { get; set; }
}

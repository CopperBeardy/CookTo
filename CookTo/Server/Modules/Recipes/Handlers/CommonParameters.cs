using CookTo.Server.Modules.Categories.Services;
using CookTo.Server.Modules.Cuisines.Services;
using CookTo.Server.Modules.Recipes.Services;
using CookTo.Server.Modules.Utensils.Services;

namespace CookTo.Server.Modules.Recipes.Handlers;


public record CommonParameters
{
    public IRecipeService RecipeService { get; set; }

    public CancellationToken CancellationToken { get; set; }
}


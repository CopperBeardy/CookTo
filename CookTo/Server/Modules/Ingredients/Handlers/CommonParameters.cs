using CookTo.Server.Modules.Categories.Services;
using CookTo.Server.Modules.Cuisines.Services;
using CookTo.Server.Modules.Ingredients.Services;
using CookTo.Server.Modules.Utensils.Services;

namespace CookTo.Server.Modules.Ingredients.Handlers;


public record CommonParameters
{
    public IIngredientService IngredientService { get; set; }

    public CancellationToken CancellationToken { get; set; }
}


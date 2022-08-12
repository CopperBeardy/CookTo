using CookTo.Server.Modules.Ingredients.Services;

namespace CookTo.Server.Modules.Ingredients.Handlers;


public record CommonParameters
{
    public IIngredientService IngredientService { get; set; }

    public CancellationToken CancellationToken { get; set; }
}


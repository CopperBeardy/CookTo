using CookTo.Server.Modules.Ingredients.Core;
using CookTo.Shared;
using CookTo.Shared.Modules.ManageIngredients;


namespace CookTo.Server.Modules.Ingredients.Handlers;

public static class GetAllHandler
{
    public static async Task<IResult> Handle(CommonParameters cp)
    {
        var entites = await cp.IngredientService.GetAllAsync(cp.CancellationToken);

        if (entites is null)
            return Results.NotFound(ErrorMessage<IngredientDocument>.ItemsNotFound());

        var ingredient = new List<Ingredient>();
        ingredient.AddRange(entites.Select(c => new Ingredient { Id = c.Id, Text = c.Text }));
        return Results.Ok(ingredient);
    }
}

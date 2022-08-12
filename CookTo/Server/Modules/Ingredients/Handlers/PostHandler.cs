using CookTo.Server.Modules.Ingredients.Core;
using CookTo.Shared.Modules.ManageIngredients;

namespace CookTo.Server.Modules.Ingredients.Handlers;

public static class PostHandler
{
    public static async Task<IResult> Handle(Ingredient ingredient, CommonParameters common)
    {
        var newIngredient = new IngredientDocument() { Text = ingredient.Text };
        await common.IngredientService.CreateAsync(newIngredient, common.CancellationToken);
        return Results.Ok(new Ingredient { Id = newIngredient.Id, Text = newIngredient.Text });
    }
}


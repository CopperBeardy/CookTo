using CookTo.Server.Modules.Categories.Core;
using CookTo.Server.Modules.Categories.Services;
using CookTo.Server.Modules.Cuisines.Core;
using CookTo.Server.Modules.Ingredients.Core;
using CookTo.Server.Modules.Utensils.Core;
using CookTo.Shared.Modules.ManageCategories;
using CookTo.Shared.Modules.ManageCuisines;
using CookTo.Shared.Modules.ManageIngredients;
using CookTo.Shared.Modules.ManageUtensils;

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


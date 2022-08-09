using CookTo.Server.Modules.Recipes.Helpers;
using CookTo.Shared.Modules.ManageRecipes;

namespace CookTo.Server.Modules.Recipes.Handlers;

public static class PutHandler
{
    public static async Task<IResult> Handle(Recipe recipe, CommonParameters cp)
    {
        if(recipe.Id is not null)
        {
            var toUpdateRecipe = RecipeToRecipeDocumentConverter.Convert(recipe);
            await cp.RecipeService.UpdateAsync(toUpdateRecipe, cp.CancellationToken);

            return Results.Ok(RecipeDocumentToRecipeConverter.Convert(toUpdateRecipe));
        }
        return Results.BadRequest();
    }
}
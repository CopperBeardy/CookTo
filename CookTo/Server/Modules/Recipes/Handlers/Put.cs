using CookTo.DataAccess.Documents.RecipeDocumentAccess.Services;
using CookTo.Server.Modules.Recipes.Helpers;
using CookTo.Shared.Modules.ManageRecipes;

namespace CookTo.Server.Modules.Recipes.Handlers;

public static class Put
{
    public static async Task<IResult> Handle(Recipe recipe, IRecipeService service, CancellationToken cancellationToken)
    {
        if(recipe.Id is not null)
        {
            var toUpdateRecipe = RecipeToRecipeDocumentConverter.Convert(recipe);
            await service.UpdateAsync(toUpdateRecipe, cancellationToken);

            return Results.Ok(RecipeDocumentToRecipeConverter.Convert(toUpdateRecipe));
        }
        return Results.BadRequest();
    }
}
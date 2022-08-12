using CookTo.Server.Modules.Recipes.Helpers;

namespace CookTo.Server.Modules.Recipes.Handlers;

public static class GetByIdHandler
{
    public static async Task<IResult> Handle(string id, CommonParameters cp)
    {
        var document = await cp.RecipeService.GetByIdAsync(id, cp.CancellationToken);
        if (document is null)
        {
            return Results.BadRequest("Recipe was not found");
        }
        var recipe = RecipeDocumentToRecipeConverter.Convert(document);
        return Results.Ok(recipe);
    }
}

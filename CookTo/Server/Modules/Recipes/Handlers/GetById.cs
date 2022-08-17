using CookTo.DataAccess.Documents.RecipeDocumentAccess.Services;
using CookTo.Server.Modules.Recipes.Helpers;

namespace CookTo.Server.Modules.Recipes.Handlers;

public static class GetById
{
    public static async Task<IResult> Handle(string id, IRecipeService service, CancellationToken cancellationToken)
    {
        var document = await service.GetByIdAsync(id, cancellationToken);
        if(document is null)
        {
            return Results.BadRequest("Recipe was not found");
        }
        var recipe = RecipeDocumentToRecipeConverter.Convert(document);
        return Results.Ok(recipe);
    }
}

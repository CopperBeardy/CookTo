using CookTo.DataAccess.Documents.RecipeDocumentAccess.Services;

namespace CookTo.Server.Modules.Recipes.Handlers;

public static class Delete
{
    public static async Task<IResult> Handle(string id, IRecipeService service, CancellationToken cancellationToken)
    {
        var recipe = await service.GetByIdAsync(id, cancellationToken);
        if(recipe is null)
        {
            return Results.NotFound();
        }
        await service.DeleteAsync(id, cancellationToken);


        return Results.NoContent();
    }
}

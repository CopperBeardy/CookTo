using CookTo.DataAccess.Documents.RecipeDocumentAccess.Services;

namespace CookTo.Server.Modules.Recipes.Handlers;

public static class Delete
{
    public static async Task Handle(string id, IRecipeService service, CancellationToken cancellationToken)
    {
        var recipe = await service.GetByIdAsync(id, cancellationToken);
        await service.DeleteAsync(id, cancellationToken);
    }
}

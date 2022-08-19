using CookTo.DataAccess.Documents.RecipeDocumentAccess.Services;
using CookTo.Server.Modules.Recipes.Helpers;
using CookTo.Shared.Modules.ManageRecipes;

namespace CookTo.Server.Modules.Recipes.Handlers;

public static class GetById
{
    public static async Task<Recipe?> Handle(string id, IRecipeService service, CancellationToken cancellationToken)
    {
        var document = await service.GetByIdAsync(id, cancellationToken);
        if(document is null)
        {
            // logger need to be added
            return null;
        }
        return RecipeDocumentToRecipeConverter.Convert(document);
        ;
    }
}

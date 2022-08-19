using CookTo.DataAccess.Documents.RecipeDocumentAccess.Services;
using CookTo.Shared.Modules;
using CookTo.Shared.Modules.ManageCategories;
using CookTo.Shared.Modules.ManageCuisines;

namespace CookTo.Server.Modules.Recipes.Handlers;

public static class GetHighlightedRecipe
{
    public static async Task<HighlightedRecipe> Handle(IRecipeService service, CancellationToken cancellationToken)
    {
        var recipe = await service.GetHighlighted(cancellationToken);

        var highlighted = new HighlightedRecipe(
            recipe.Id,
            new Category { Id = recipe.Id, Name = recipe.Category.Name },
            recipe.Title,
            new Cuisine { Id = recipe.Cuisine.Id, Name = recipe.Cuisine.Name },
            recipe.Image,
            recipe.Creator,
            recipe.AddedBy,
            recipe.PrepTime,
            recipe.CookTime,
            recipe.Description,
            recipe.Dietaries,
            recipe.ShoppingList,
            recipe.Tags);

        return highlighted;
    }
}

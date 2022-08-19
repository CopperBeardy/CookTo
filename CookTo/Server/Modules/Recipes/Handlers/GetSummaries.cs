using CookTo.DataAccess.Documents.RecipeDocumentAccess.Services;
using CookTo.Shared.Modules;
using CookTo.Shared.Modules.ManageCategories;
using CookTo.Shared.Modules.ManageCuisines;


namespace CookTo.Server.Modules.Recipes.Handlers;

public static class GetSummaries
{
    public static async Task<List<RecipeSummary>?> Handle(int amount, IRecipeService service, CancellationToken cancellationToken)
    {
        var response = await service.GetSummaries(amount, cancellationToken, 0);
        var summaries = new List<RecipeSummary>();
        if (response is not null || response.Any())

            summaries.AddRange(response.Select(recipe => new RecipeSummary(
                recipe.Id,
                new Category { Id = recipe.Id, Name = recipe.Category.Name },
                recipe.Title,
                new Cuisine { Id = recipe.Cuisine.Id, Name = recipe.Cuisine.Name },
                recipe.Image,
                recipe.Creator,
                recipe.AddedBy,
                recipe.Dietaries,
                recipe.ShoppingList,
                recipe.Tags)));
        return summaries;
    }
}

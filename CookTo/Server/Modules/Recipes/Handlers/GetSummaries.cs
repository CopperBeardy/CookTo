using CookTo.DataAccess.Documents.RecipeDocumentAccess.Services;
using CookTo.Shared.Modules;
using CookTo.Shared.Modules.ManageCategories;
using CookTo.Shared.Modules.ManageCuisines;


namespace CookTo.Server.Modules.Recipes.Handlers;

public static class GetSummaries
{
    public static async Task<IResult> Handle(int amount, IRecipeService service, CancellationToken cancellationToken)
    {
        var recipes = await service.GetSummaries(amount, cancellationToken, 0);
        if(recipes is null || recipes.Count == 0)
        {
            return Results.BadRequest("Recipe was not found");
        }
        var summaries = new List<RecipeSummary>();
        summaries.AddRange(recipes.Select(recipe => new RecipeSummary(
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
        return Results.Ok(summaries);
    }
}

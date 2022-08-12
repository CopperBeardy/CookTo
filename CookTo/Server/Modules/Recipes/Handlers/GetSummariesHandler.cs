using CookTo.Shared.Modules;
using CookTo.Shared.Modules.ManageCategories;
using CookTo.Shared.Modules.ManageCuisines;


namespace CookTo.Server.Modules.Recipes.Handlers;

public static class GetSummariesHandler
{
    public static async Task<IResult> Handle(int amount, CommonParameters cp)
    {
        var recipes = await cp.RecipeService.GetSummaries(amount, cp.CancellationToken, 0);
        if (recipes is null || recipes.Count == 0)
        {
            return Results.BadRequest("Recipe was not found");
        }
        var summaries = new List<RecipeSummary>();
        summaries.AddRange(recipes.Select(recipe => new RecipeSummary(
            recipe.Id,
            new Category { Id = recipe.Id, Text = recipe.Category.Text },
            recipe.Title,
            new Cuisine { Id = recipe.Cuisine.Id, Text = recipe.Cuisine.Text },
            recipe.Image,
            recipe.Creator,
            recipe.AddedBy,
            recipe.Dietaries,
            recipe.ShoppingList,
            recipe.Tags)));
        return Results.Ok(summaries);
    }
}

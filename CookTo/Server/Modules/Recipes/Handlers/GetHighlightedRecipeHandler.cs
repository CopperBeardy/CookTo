using CookTo.Shared.Modules;
using CookTo.Shared.Modules.ManageCategories;
using CookTo.Shared.Modules.ManageCuisines;

namespace CookTo.Server.Modules.Recipes.Handlers;

public static class GetHighlightedRecipeHandler
{
    public static async Task<IResult> Handle(CommonParameters cp)
    {
        var recipe = await cp.RecipeService.GetHighlighted(cp.CancellationToken);
        if (recipe is null)
        {
            return Results.BadRequest("Recipe was not found");
        }

        var highlighted = new HighlightedRecipe(
            recipe.Id,
            new Category { Id = recipe.Id, Text = recipe.Category.Text },
            recipe.Title,
            new Cuisine { Id = recipe.Cuisine.Id, Text = recipe.Cuisine.Text },
            recipe.Image,
            recipe.Creator,
            recipe.AddedBy,
            recipe.PrepTime,
            recipe.CookTime,
            recipe.Description,
            recipe.Dietaries,
            recipe.ShoppingList,
            recipe.Tags);
        return Results.Ok(highlighted);
    }
}

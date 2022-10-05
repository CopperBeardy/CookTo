using CookTo.Shared.Models.ManageCategories;
using CookTo.Shared.Models.ManageCuisines;
using CookTo.Shared.Models.ManageRecipes;

namespace CookTo.Server.Helpers;

public static class TagHelper
{
    public static string GenerateTags(Category category, Cuisine cuisine, List<RecipePartIngredient> recipePartIngredients)
    {
        List<string> tags = new List<string>();
        tags.Add(GetCategory(category));
        tags.Add(GetCuisine(cuisine));
        tags.AddRange(GetIngredients(recipePartIngredients));
        var tagstring = tags.Aggregate(string.Empty, (accumulator, t) => accumulator += $"{t},").TrimEnd(',');

        return tagstring;
    }

    private static string GetCategory(Category category) => category.Name;

    private static string GetCuisine(Cuisine cuisine) => cuisine.Name;

    private static List<string> GetIngredients(List<RecipePartIngredient> partIngredients)
    {
        List<string> ingredients = new List<string>();
        foreach(var item in partIngredients)
        {
            if(!ingredients.Contains(item.Ingredient.Name))
                ingredients.Add(item.Ingredient.Name);
        }
        return ingredients;
    }
}

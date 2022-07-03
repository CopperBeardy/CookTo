using CookTo.Server.Modules.Categories.Core;
using CookTo.Server.Modules.Cuisines.Core;
using CookTo.Server.Modules.Recipes.Core;
using System.Linq;

namespace CookTo.Server.Modules.Recipes.Helpers;

public static class TagHelper
{
    public static  string GenerateTags(RecipeDocument recipe)
    {
        List<string> tags = new List<string>();
        tags.Add(GetCategory(recipe.Category));
        tags.Add(GetCuisine(recipe.Cuisine));
        tags.AddRange(GetIngredients(recipe.ShoppingList));
        var tagstring = tags.Aggregate(string.Empty, (accumulator, t) => accumulator += $"{t},").TrimEnd(',');

        return tagstring;
    }

    private static string GetCategory(CategoryDocument category) => category.Text;

    private static string GetCuisine(CuisineDocument cuisine) => cuisine.Text;

    private static List<string> GetIngredients(List<ShoppingItemDocument> ShoppingList)
    {
        List<string> ingredients = new List<string>();
        foreach(var item in ShoppingList)
        {
            ingredients.Add(item.Ingredient.Text);
        }
        return ingredients;
    }
}

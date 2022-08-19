using CookTo.Shared.Modules.ManageCategories;
using CookTo.Shared.Modules.ManageCuisines;
using CookTo.Shared.Modules.ManageRecipes;

namespace CookTo.Server.Modules.Recipes.Helpers;

public static class TagHelper
{
    public static string GenerateTags(Category category, Cuisine cuisine, List<ShoppingItem> shoppingItems)
    {
        List<string> tags = new List<string>();
        tags.Add(GetCategory(category));
        tags.Add(GetCuisine(cuisine));
        tags.AddRange(GetIngredients(shoppingItems));
        var tagstring = tags.Aggregate(string.Empty, (accumulator, t) => accumulator += $"{t},").TrimEnd(',');

        return tagstring;
    }

    private static string GetCategory(Category category) => category.Name;

    private static string GetCuisine(Cuisine cuisine) => cuisine.Name;

    private static List<string> GetIngredients(List<ShoppingItem> ShoppingList)
    {
        List<string> ingredients = new List<string>();
        foreach (var item in ShoppingList)
        {
            ingredients.Add(item.Ingredient.Name);
        }
        return ingredients;
    }
}

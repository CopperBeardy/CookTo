using CookTo.Shared.Models.ManageCategories;
using CookTo.Shared.Models.ManageCuisines;
using CookTo.Shared.Models.ManageIngredients;
using CookTo.Shared.Models.ManageRecipes;

namespace CookTo.Server.Helpers;

public static class TagHelper
{
    public static string GenerateTags(Category category, Cuisine cuisine, List<Ingredient> ingredients)
    {
        List<string> tags = new List<string>();

        tags.Add(GetCategory(category));
        if(GetCuisine(cuisine) != "na")
        {
            tags.Add(GetCuisine(cuisine));
        }

        tags.AddRange(GetIngredients(ingredients));
        var tagstring = tags.Aggregate(string.Empty, (accumulator, t) => accumulator += $"{t},").TrimEnd(',');

        return tagstring;
    }

    private static string GetCategory(Category category) => category.Name;

    private static string GetCuisine(Cuisine cuisine) => cuisine.Name;

    private static List<string> GetIngredients(List<Ingredient> ingredients)
    {
        List<string> _ingredients = new List<string>();
        foreach(var item in ingredients)
        {
            if(!_ingredients.Contains(item.Name))
                _ingredients.Add(item.Name);
        }
        return _ingredients;
    }
}

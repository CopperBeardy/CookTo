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
        tags.AddRange(GetIngredients(recipe.CookingSteps));
        var tagstring = tags.Aggregate(string.Empty, (accumulator, t) => accumulator += $"{t},");

        return tagstring;
    }

    private static string GetCategory(CategoryDocument category) => category.Text;

    private static string GetCuisine(CuisineDocument cuisine) => cuisine.Text;

    private static List<string> GetIngredients(List<CookingStepDocument> cookingSteps)
    {
        List<string> ingredients = new List<string>();
        foreach(var step in cookingSteps)
        {
            foreach(var ing in step.StepIngredients)
            {
                ingredients.Add(ing.Ingredient.Text);
            }
        }
        return ingredients;
    }
}

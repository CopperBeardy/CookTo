using CookTo.Shared.Models.ManageRecipes;

namespace CookTo.Server.Helpers;

internal static class RecipeHelper
{
    public static async Task<Recipe> CompleteRecipe(Recipe recipe)
    {
        List<RecipePartIngredient> GatheredIngredients = GatherAllIngredients(recipe.RecipeParts);
        List<RecipePartIngredient> NormalizedIngredients = NormalizeIngredients(GatheredIngredients);
        List<RecipePartIngredient> AggregatedIngredient = AggregateIngredients(NormalizedIngredients);
        recipe.Tags = TagHelper.GenerateTags( recipe.Category, recipe.Cuisine, recipe.ContainedIngredients);
        recipe.ShoppingList = ShoppingListHelper.CreateShoppingList(AggregatedIngredient);

        return recipe;
    }

    public static List<RecipePartIngredient> GatherAllIngredients(List<RecipePart> recipeParts)
    {
        List<RecipePartIngredient> ingredients = new();
        foreach(var part in recipeParts)
        {
            ingredients.AddRange(part.RecipePartIngredients);
        }
        return ingredients;
    }

    public static List<RecipePartIngredient> NormalizeIngredients(List<RecipePartIngredient> recipePartIngredients)
    {
        List<RecipePartIngredient> ingredients = new();
        foreach(var ingredient in recipePartIngredients)
        {
            switch(ingredient.Measure)
            {
                case Shared.Enums.MeasureUnit.pinch:
                    ingredient.Quantity = "1";
                    ingredient.Measure = Shared.Enums.MeasureUnit.g;
                    break;
                case Shared.Enums.MeasureUnit.tsp_g:
                    ingredient.Quantity = (int.Parse(ingredient.Quantity) * 2).ToString();
                    ingredient.Measure = Shared.Enums.MeasureUnit.g;
                    break;
                case Shared.Enums.MeasureUnit.tbsp_g:
                    ingredient.Quantity = (int.Parse(ingredient.Quantity) * 4).ToString();
                    ingredient.Measure = Shared.Enums.MeasureUnit.g;
                    break;
                case Shared.Enums.MeasureUnit.tsp_ml:
                    ingredient.Quantity = (int.Parse(ingredient.Quantity) * 5).ToString();
                    ingredient.Measure = Shared.Enums.MeasureUnit.ml;
                    break;
                case Shared.Enums.MeasureUnit.tbsp_ml:
                    ingredient.Quantity = (int.Parse(ingredient.Quantity) * 10).ToString();
                    ingredient.Measure = Shared.Enums.MeasureUnit.ml;
                    break;
            }

            ingredients.Add(ingredient);

            foreach(var item in ingredients)
            {
                if(!int.TryParse(item.Quantity, out _))
                {
                    item.Quantity = "1";
                }
            }
        }
        return ingredients;
    }

    public static List<RecipePartIngredient> AggregateIngredients(List<RecipePartIngredient> recipePartIngredients)
    {
        var aggregatedItems = new List<RecipePartIngredient>();
        foreach(var ingredient in recipePartIngredients)
        {
            var item = aggregatedItems.FindIndex(x => x.Ingredient.Name == ingredient.Ingredient.Name);
            if(item > -1)
            {
                aggregatedItems[item].Quantity = (int.Parse(aggregatedItems[item].Quantity) +
                    int.Parse(ingredient.Quantity)).ToString();
            } else
            {
                aggregatedItems.Add(ingredient);
            }
        }
        return aggregatedItems;
    }
}

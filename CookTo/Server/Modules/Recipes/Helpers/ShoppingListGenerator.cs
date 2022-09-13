using CookTo.DataAccess.Documents.IngredientDocumentAccess.Services;
using CookTo.DataAccess.Documents.RecipeDocumentAccess;
using CookTo.Shared.Modules.ManageRecipes;
using System.Text;

namespace CookTo.Server.Modules.Recipes.Helpers;

public  static class ShoppingListGenerator
{
    public static List<string> Generate(List<RecipePart> recipeParts)
    {
        List<RecipePartIngredient> GatheredIngredients = GatherAllIngredients(recipeParts);
        List<RecipePartIngredient> NormalizedIngredients = NormalizeIngredients(GatheredIngredients);

        return new();
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
        }
        return ingredients;
    }

    public static List<string> ConvertToStringList(List<ShoppingItem> items)
    {
        var shoppingList = new List<string>();
        foreach(var item in items)
        {
            var builder = new StringBuilder();
            if(item.Quantity != string.Empty)
            {
                builder.Append(item.Quantity);
            }
            if(item.Measure != string.Empty)
            {
                builder.Append(item.Measure);
            }
            builder.Append(" ");
            builder.Append(item.Ingredient.Name);

            if(item.AdditionalInformation != string.Empty)
            {
                builder.Append(", ");
                builder.Append(item.AdditionalInformation);
            }
            shoppingList.Add(builder.ToString().Trim());
        }
        return shoppingList;
    }
}

using CookTo.Server.Documents.RecipeDocument;
using System.Text;

namespace CookTo.Server.Helpers;

public static class ShoppingList
{
    public static List<string> Generate(Recipe recipe)
    {
        List<SectionPartIngredient> ingredients = GatherIngredients(recipe);
        ingredients = NormalizeIngredients(ingredients);
        ingredients = GroupByIngredientName(ingredients);
        List<string> shoppingList = CreateShoppingListValues(ingredients);

        return shoppingList;
    }

    private static List<SectionPartIngredient> NormalizeIngredients(this List<SectionPartIngredient> ingredients)
    {
        for(int i = 0; i < ingredients.Count; i++)
        {
            var ingredient = ingredients[i];
            var unit = ingredient.Unit;
            switch(unit)
            {
                case MeasureUnit.pinch:
                case MeasureUnit.tsp_dry:
                case MeasureUnit.tbsp_dry:
                    ingredients[i] = ConvertToGrams(ingredient);
                    break;
                case MeasureUnit.tsp_liquid:
                case MeasureUnit.tbsp_liquid:
                    ingredients[i] = ConvertToMilliliters(ingredient);
                    break;
            }
        }
        return ingredients;
    }

    private static List<SectionPartIngredient> GatherIngredients(Recipe recipe)
    {
        var ingredients = new List<SectionPartIngredient>();
        foreach(var part in recipe.RecipeParts)
        {
            ingredients.AddRange(part.Items);
        }
        return ingredients;
    }

    public static List<string> CreateShoppingListValues(this List<SectionPartIngredient> ingredients)
    {
        var shoppingList = new List<string>();
        foreach(var ingredient in ingredients)
        {
            var sb = new StringBuilder();
            if(ingredient.Unit == MeasureUnit.None)
            {
                switch(ingredient.Amount)
                {
                    case 1:
                        sb.Append("A ");
                        break;
                    default:
                        sb.Append($"{ingredient.Amount} ");
                        sb.Append($"{ingredient.Ingredient.Name}'s");
                        shoppingList.Add(sb.ToString());
                        continue;
                }
            } else
            {
                sb.Append($"{ingredient.Amount}");
                sb.Append($"{Enum.GetName(typeof(MeasureUnit),ingredient.Unit)}");
                sb.Append(" ");
            }
            sb.Append($"{ingredient.Ingredient.Name}");
            shoppingList.Add(sb.ToString());
        }

        return shoppingList;
    }

    public static List<SectionPartIngredient> GroupByIngredientName(this List<SectionPartIngredient> ingredients)
    {
        return ingredients.GroupBy(n => n.Ingredient.Name)
            .Select(
                i => new SectionPartIngredient
                {
                    Amount = i.Sum(a => a.Amount),
                    AdditionalInformation = i.First().AdditionalInformation,
                    Ingredient = i.First().Ingredient,
                    Unit = i.First().Unit
                })
            .ToList();
    }

    public static SectionPartIngredient ConvertToGrams(SectionPartIngredient ingredient)
    {
        switch(ingredient.Unit)
        {
            case MeasureUnit.pinch:
                ingredient.Amount = Math.Ceiling(1.5 * ingredient.Amount);
                break;
            case MeasureUnit.tsp_dry:
                ingredient.Amount = Math.Ceiling(6 * ingredient.Amount);
                break;
            case MeasureUnit.tbsp_dry:
                ingredient.Amount = Math.Ceiling(15 * ingredient.Amount);
                break;
        }
        ingredient.Unit = MeasureUnit.g;
        return ingredient;
    }

    public static SectionPartIngredient ConvertToMilliliters(SectionPartIngredient ingredient)
    {
        switch(ingredient.Unit)
        {
            case MeasureUnit.tsp_liquid:
                ingredient.Amount = Math.Ceiling(5 * ingredient.Amount);
                break;
            case MeasureUnit.tbsp_liquid:
                ingredient.Amount = Math.Ceiling(15 * ingredient.Amount);
                break;
        }
        ingredient.Unit = MeasureUnit.ml;
        return ingredient;
    }
}

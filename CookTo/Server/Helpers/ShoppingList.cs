using CookTo.Server.Documents;
using CookTo.Shared.Features.ManageRecipes;
using System.Text;

namespace CookTo.Server.Helpers;

public static class ShoppingList
{
    public static List<string> Generate(List<CookingStep> steps)
    {
       
        var ingredients = GatherIngredients(steps);
        var normalizedIngredients = NormalizeIngredients(ingredients);
        var groupedIngredients = GroupByIngredientName(normalizedIngredients);
        List<string> shoppingList = CreateShoppingListValues(groupedIngredients);

        return shoppingList;
    }

    private static List<StepIngredient> NormalizeIngredients(this List<StepIngredient> ingredients)
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

    public static List<StepIngredient> GatherIngredients(List<CookingStep> steps)
    {
        var ingredients = new List<StepIngredient>();
        foreach(var step in steps)
        {
            ingredients.AddRange(step.StepIngredients);
        }
        return ingredients;
    }

    public static List<string> CreateShoppingListValues(this List<StepIngredient> ingredients)
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
                        sb.Append($"{ingredient.Ingredient.Text}'s");
                        shoppingList.Add(sb.ToString());
                        continue;
                }
            } else
            {
                sb.Append($"{ingredient.Amount}");
                sb.Append($"{Enum.GetName(typeof(MeasureUnit),ingredient.Unit)}");
                sb.Append(" ");
            }
            sb.Append($"{ingredient.Ingredient.Text}");
            shoppingList.Add(sb.ToString());
        }

        return shoppingList;
    }

    public static List<StepIngredient> GroupByIngredientName(this List<StepIngredient> ingredients)
    {
        return ingredients.GroupBy(n => n.Ingredient.Text)
            .Select(
                i => new StepIngredient
                {
                    Amount = i.Sum(a => a.Amount),
                    AdditionalInformation = i.First().AdditionalInformation,
                    Ingredient = i.First().Ingredient,
                    Unit = i.First().Unit
                })
            .ToList();
    }

    public static StepIngredient ConvertToGrams(StepIngredient ingredient)
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

    public static StepIngredient ConvertToMilliliters(StepIngredient ingredient)
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

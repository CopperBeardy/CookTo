using CookTo.Shared.Enums;
using CookTo.Shared.Models.ManageIngredients;
using System.Text;

namespace CookTo.Client.Modules.ManageRecipes.RecipeDisplayComponents;

public static class IngredientDisplayHelper
{
    public static string Format(string Quantity, MeasureUnit unit, string ingredient, string additonalInformation = default)
    {
        StringBuilder stringBuilder = new();
        if(Quantity != string.Empty && Quantity != "0")
        {
            stringBuilder.Append(Quantity);
        }

        if(unit != MeasureUnit.None)
        {
            stringBuilder.Append(Enum.GetName(typeof(MeasureUnit), unit));
        }

        stringBuilder.Append(" ");
        stringBuilder.Append(ingredient);

        if(!string.IsNullOrEmpty(additonalInformation))
        {
            stringBuilder.Append(", ");
            stringBuilder.Append(additonalInformation);
        }

        return stringBuilder.ToString().Trim();
    }
}

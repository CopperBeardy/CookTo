using CookTo.Shared.Enums;
using CookTo.Shared.Modules.ManageIngredients;
using System.Text;

namespace CookTo.Shared.Modules.ManageRecipes;

public class RecipePartIngredient
{
    public string Quantity { get; set; } = string.Empty;

    public MeasureUnit Measure { get; set; } = MeasureUnit.None;

    public Ingredient Ingredient { get; set; } = new Ingredient();

    public string? AdditionalInformation { get; set; } = string.Empty;

    public override string ToString()
    {
        StringBuilder stringBuilder = new();
        if(!string.IsNullOrEmpty(Quantity))
        {
            stringBuilder.Append(Quantity);
        }

        if(Measure != MeasureUnit.None)
        {
            stringBuilder.Append(Enum.GetName(typeof(MeasureUnit), Measure));
        }

        stringBuilder.Append(" ");
        stringBuilder.Append(Ingredient.Name);

        if(!string.IsNullOrEmpty(AdditionalInformation))
        {
            stringBuilder.Append(", ");
            stringBuilder.Append(AdditionalInformation);
        }

        return stringBuilder.ToString().Trim();
    }
}

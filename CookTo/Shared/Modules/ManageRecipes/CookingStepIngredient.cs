using CookTo.Shared.Enums;
using CookTo.Shared.Modules.ManageIngredients;
using System.Text;

namespace CookTo.Shared.Modules.ManageRecipes;

public class CookingStepIngredient
{
    public string? Quantity { get; set; }

    public MeasureUnit Measure { get; set; } = MeasureUnit.None;

    public Ingredient Ingredient { get; set; }

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


        return stringBuilder.ToString().Trim();
    }
}


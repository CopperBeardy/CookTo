using CookTo.Shared.Enums;
using CookTo.Shared.Models.ManageIngredients;
using System.Text;

namespace CookTo.Shared.Models.ManageRecipes;

public sealed class CookingStepIngredient
{
    public string? Quantity { get; set; }

    public MeasureUnit Measure { get; set; } = MeasureUnit.None;

    public Ingredient Ingredient { get; set; } = new();

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


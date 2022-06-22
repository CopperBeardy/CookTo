using CookTo.Shared.Enums;
using CookTo.Shared.Modules.ManageIngredients;
using System.Text;

namespace CookTo.Shared.Modules.ManageRecipes;

public class StepIngredient
{
    public double Amount { get; set; }
    public MeasureUnit Unit { get; set; }

    public Ingredient Ingredient { get; set; } = new Ingredient();

    public string? AdditionalInformation { get; set; }

    public override string ToString()
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.Append(Amount);
        if (Unit != MeasureUnit.None)
        {
            var unit = Enum.GetName(typeof(MeasureUnit), Unit);
            if (unit is not null)
            {
                if (unit.StartsWith("tsp"))
                {
                    unit = "tsp";
                }
                else if (unit.StartsWith("tbsp"))
                {
                    unit = "tbsp";
                }
            }
            stringBuilder.Append(unit);
        }
        stringBuilder.Append($" {Ingredient.Text}");
        return stringBuilder.ToString();
    }
}


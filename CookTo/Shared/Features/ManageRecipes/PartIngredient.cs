using CookTo.Shared.Enums;
using CookTo.Shared.Models;
using System.Text;

namespace CookTo.Shared.Features.ManageRecipes;

public class PartIngredient
{
    public double Amount { get; set; }
    public MeasureUnit Unit { get; set; }

    public Ingredient Ingredient { get; set; } = new Ingredient();

    public string? AdditionalInformation { get; set; }

    public override string ToString()
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.Append(Amount);
        stringBuilder.Append(Enum.GetName(typeof(MeasureUnit), Unit));
        stringBuilder.Append($" {Ingredient.Text}");
        return stringBuilder.ToString();
    }
}


using CookTo.Shared.Enums;
using CookTo.Shared.Features.ManageIngredients;

namespace CookTo.Shared.Features.ManageRecipes;

public class PartIngredient
{
    [JsonPropertyName("amount")]
    public double Amount { get; set; } = 0;
    [JsonPropertyName("unit")]
    public MeasureUnit Unit { get; set; } = MeasureUnit._;
    [JsonPropertyName("ingredientName")]
    public string IngredientName { get; set; } = string.Empty;
    [JsonPropertyName("additionalInformation")]
    public string? AdditionalInformation { get; set; }


    //Todo: move to display
    public override string ToString() => $"{Amount}{Enum.GetName(Unit)} {IngredientName} {AdditionalInformation}".TrimEnd(
        );
}


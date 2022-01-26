using CookTo.Shared.Enums;
using CookTo.Shared.Features.ManageIngredients;

namespace CookTo.Shared.Features.ManageRecipes;

public class PartIngredient
{
    [JsonPropertyName("amount")]
    public double Amount { get; set; } = 0;
    [JsonPropertyName("unit")]
    public MeasureUnit Unit { get; set; } = MeasureUnit._;
    [JsonPropertyName("partingredientname")]
    public IngredientDto Ingredient { get; set; } = new();
    [JsonPropertyName("partingredientdescription")]
    public string? Description { get; set; } = string.Empty;

    public override string ToString() => $"{Amount}{Enum.GetName(Unit)} {Ingredient.Name} {Description}".TrimEnd();
}


﻿using CookTo.Shared.Enums;

namespace CookTo.Shared.Features.ManageRecipes;

public class PartIngredient
{
    [JsonPropertyName("amount")]
    public double Amount { get; set; } = 0.0;

    [JsonPropertyName("unit")]
    public MeasureUnit Unit { get; set; } = MeasureUnit._;
    [JsonPropertyName("ingredientName")]
    public string IngredientName { get; set; } = string.Empty;
    [JsonPropertyName("additionalInformation")]
    public string? AdditionalInformation { get; set; } = string.Empty;


    //Todo: move to display
    public override string ToString() => $"{Amount}{Enum.GetName(Unit)} {IngredientName} {AdditionalInformation}".TrimEnd(
        );
}


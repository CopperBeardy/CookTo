﻿using CookTo.Shared.Enums;

namespace CookTo.Shared.Features.ManageRecipes;

public partial class RecipeDto
{
    public partial class RecipePart
    {
        public class PartIngredient
        {
            [JsonPropertyName("amount")]
            public double? Amount { get; set; } = 0;
            [JsonPropertyName("unit")]
            public MeasureUnit Unit { get; set; } = MeasureUnit.g;
            [JsonPropertyName("partingredientname")]
            public string Name { get; set; } = string.Empty;
            [JsonPropertyName("partingredientdescription")]
            public string? Description { get; set; } = string.Empty;
        }
    }
}

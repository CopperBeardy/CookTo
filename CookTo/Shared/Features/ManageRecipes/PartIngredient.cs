using CookTo.Shared.Enums;
using CookTo.Shared.Features.ManageIngredients;

namespace CookTo.Shared.Features.ManageRecipes;

public class PartIngredient
{
    public double Amount { get; set; }

    public string? PartIngredientReferenceCode { get; set; }

    public MeasureUnit Unit { get; set; }

    public IngredientDto Ingredient { get; set; } = new IngredientDto();

    public string? AdditionalInformation { get; set; }
}


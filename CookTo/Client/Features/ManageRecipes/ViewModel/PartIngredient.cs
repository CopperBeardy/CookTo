using CookTo.Shared.Enums;

namespace CookTo.Client.Features.ManageRecipes.ViewModel;

public class PartIngredient
{
    public double Amount { get; set; }

    public MeasureUnit Unit { get; set; }

    public string IngredientName { get; set; }

    public string? AdditionalInformation { get; set; }
}


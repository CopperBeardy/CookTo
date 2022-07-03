using CookTo.Shared.Enums;
using CookTo.Shared.Modules.ManageIngredients;
using System.Text;

namespace CookTo.Shared.Modules.ManageRecipes;

public class StepIngredient
{
    public string? Quantity { get; set; }

    public string? Measure { get; set; }

    public string? Ingredient { get; set; }

    public string? AdditionalInformation { get; set; }
}


using CookTo.Shared.Modules.ManageIngredients;
using System;
using System.Linq;

namespace CookTo.Shared.Modules.ManageRecipes;

public class PartIngredient
{
    public string Quantity { get; set; } = string.Empty;

    public string Measure { get; set; } = string.Empty;

    public Ingredient Ingredient { get; set; } = new Ingredient();

    public string? AdditionalInformation { get; set; } = string.Empty;
}

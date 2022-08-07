using CookTo.Server.Modules.Ingredients.Core;

namespace CookTo.Server.Modules.Recipes.Core;

public class ShoppingItemDocument
{
    public string Quantity { get; set; }

    public string Measure { get; set; }

    public IngredientDocument Ingredient { get; set; }

    public string? AdditionalInformation { get; set; }
}

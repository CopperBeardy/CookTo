using CookTo.DataAccess.Documents.IngredientDocumentAccess;

namespace CookTo.DataAccess.Documents.RecipeDocumentAccess;

public class ShoppingItemDocument
{
    public string? Quantity { get; set; }

    public string? Measure { get; set; }

    public IngredientDocument Ingredient { get; set; }

    public string? AdditionalInformation { get; set; }
}

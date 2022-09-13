using CookTo.DataAccess.Documents.IngredientDocumentAccess;
using CookTo.Shared.Enums;

namespace CookTo.DataAccess.Documents.RecipeDocumentAccess;

public class CookingStepIngredientDocument
{
    public string? Quantity { get; set; }

    public MeasureUnit Measure { get; set; }

    public IngredientDocument Ingredient { get; set; }
}

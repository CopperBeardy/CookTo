using CookTo.DataAccess.Documents.IngredientDocumentAccess;
using CookTo.Shared.Modules.ManageIngredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookTo.DataAccess.Documents.RecipeDocumentAccess;

public class PartIngredientDocument
{
    public string Quantity { get; set; } = string.Empty;

    public string Measure { get; set; } = string.Empty;

    public IngredientDocument Ingredient { get; set; } = new IngredientDocument();

    public string? AdditionalInformation { get; set; } = string.Empty;
}

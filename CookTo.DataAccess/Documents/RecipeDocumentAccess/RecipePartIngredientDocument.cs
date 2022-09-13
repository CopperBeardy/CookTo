using CookTo.DataAccess.Documents.IngredientDocumentAccess;
using CookTo.Shared.Enums;
using CookTo.Shared.Modules.ManageIngredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookTo.DataAccess.Documents.RecipeDocumentAccess;

public class RecipePartIngredientDocument
{
    public string Quantity { get; set; } = string.Empty;

    public MeasureUnit Measure { get; set; } = MeasureUnit.None;

    public IngredientDocument Ingredient { get; set; } = new ();

    public string? AdditionalInformation { get; set; } = string.Empty;
}

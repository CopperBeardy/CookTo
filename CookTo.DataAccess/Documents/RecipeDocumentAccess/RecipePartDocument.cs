using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookTo.DataAccess.Documents.RecipeDocumentAccess;

public  class RecipePartDocument
{
    public string Title { get; set; } = string.Empty;

    public List<PartIngredientDocument> PartIngredients { get; set; } = new List<PartIngredientDocument>();
}

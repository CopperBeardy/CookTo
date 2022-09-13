using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookTo.DataAccess.Documents.RecipeDocumentAccess;

public  class RecipePartDocument
{
    public string Title { get; set; } = string.Empty;

    public List<RecipePartIngredientDocument> RecipePartIngredients { get; set; } = new List<RecipePartIngredientDocument>();
}

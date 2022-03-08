using CookTo.Server.Documents.UtensilDocument;
using CookTo.Server.Helpers;
using System.Text;
using System.Text.RegularExpressions;

namespace CookTo.Server.Documents.IngredientDocument;

public static class IngredientFormatter
{
    public static Ingredient Format(Ingredient ingredient)
    {
        ingredient.Name = ParseText.TitleCapitalize(ingredient.Name);
        return ingredient;
    }
}

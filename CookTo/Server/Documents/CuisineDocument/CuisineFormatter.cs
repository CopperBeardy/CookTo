using CookTo.Server.Documents.IngredientDocument;
using CookTo.Server.Documents.UtensilDocument;
using CookTo.Server.Helpers;
using System.Text;
using System.Text.RegularExpressions;

namespace CookTo.Server.Documents.CuisineDocument;

public static class CuisineFormatter
{
    public static Cuisine Format(Cuisine cuisine)
    {
        cuisine.Name = ParseText.TitleCapitalize(cuisine.Name);
        return cuisine;
    }
}

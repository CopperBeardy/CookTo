using CookTo.Server.Documents.CuisineDocument;
using CookTo.Server.Documents.IngredientDocument;
using CookTo.Server.Documents.UtensilDocument;
using CookTo.Server.Helpers;
using CookTo.Shared.Features.ManageCategory;
using System.Text;
using System.Text.RegularExpressions;

namespace CookTo.Server.Documents.CategoryDocument;

public static class CategoryFormatter
{
    public static Category Format(Category category)
    {
        category.Name = ParseText.TitleCapitalize(category.Name);
        return category;
    }
}

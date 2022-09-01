using CookTo.DataAccess.Documents.RecipeDocumentAccess;
using System.Text;

namespace CookTo.Server.Modules.Recipes.Helpers;

public  static class ShoppingListGenerator
{
    public static List<string> Generate(List<ShoppingItemDocument> items)
    {
        var shoppingList = new List<string>();
        foreach(var item in items)
        {
            var builder = new StringBuilder();
            if(item.Quantity != string.Empty)
            {
                builder.Append(item.Quantity);
            }
            if(item.Measure != string.Empty)
            {
                builder.Append(item.Measure);
            }
            builder.Append(" ");
            builder.Append(item.Ingredient.Name);

            if(item.AdditionalInformation != string.Empty)
            {
                builder.Append(", ");
                builder.Append(item.AdditionalInformation);
            }
            shoppingList.Add(builder.ToString().Trim());
        }
        return shoppingList;
    }
}

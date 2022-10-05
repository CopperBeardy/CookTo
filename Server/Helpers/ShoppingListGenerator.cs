
using CookTo.Shared.Models.ManageRecipes;
using MongoDB.Driver;
using System.Linq;
using System.Text;

namespace CookTo.Server.Helpers;

public  static class ShoppingListHelper
{
    public static List<string> CreateShoppingList(List<RecipePartIngredient> items)
    {
        var shoppingList = new List<string>();
        foreach(var item in items)
        {
            var builder = new StringBuilder();
            if(item.Quantity != string.Empty || item.Quantity != "0")
            {
                builder.Append(item.Quantity);
            }
            if(item.Measure != Shared.Enums.MeasureUnit.None)
            {
                builder.Append(item.Measure);
            }
            builder.Append(" ");
            builder.Append(item.Ingredient.Name);


            shoppingList.Add(builder.ToString().Trim());
        }
        return shoppingList;
    }
}


using CookTo.Shared.Models.ManageRecipes;
using MongoDB.Driver;
using System.Linq;
using System.Text;

namespace CookTo.Server.Helpers;

internal  static class ShoppingListHelper
{
    public static List<string> CreateShoppingList(List<RecipePartIngredient> items)
    {
        var shoppingList = new List<string>();
        foreach(var item in items)
        {
            var builder = new StringBuilder();
            if(item.Quantity != "0" || string.IsNullOrEmpty(item.Quantity))
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

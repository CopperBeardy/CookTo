using CookTo.Shared.Enums;
using CookTo.Shared.Models.ManageIngredients;
using System.Text;

namespace CookTo.Shared.Models.ManageRecipes;

public sealed class ShoppingItem
{
    public string Quantity { get; set; } = string.Empty;

    public MeasureUnit Measure { get; set; } = MeasureUnit.None;

    public Ingredient Ingredient { get; set; } = new Ingredient();


    public override string ToString()
    {
        var sb = new StringBuilder();
        if(Quantity is not null | Quantity != string.Empty)
        {
            sb.Append($"{Quantity} ");
        }
        if(Measure != MeasureUnit.None)
        {
            sb.Append($"{Measure} ");
        }
        if(Ingredient is not null)
        {
            sb.Append($"{Ingredient.Name} ");
        }

        return sb.ToString();
    }
}


using CookTo.Shared.Modules.ManageIngredients;
using System.Text;

namespace CookTo.Shared.Modules.ManageRecipes;

public class ShoppingItem
{
    public string Quantity { get; set; } = string.Empty;

    public string Measure { get; set; } = string.Empty;

    public Ingredient Ingredient { get; set; } = new Ingredient();

    public string? AdditionalInformation { get; set; } = string.Empty;

    public override string ToString()
    {
        var sb = new StringBuilder();
        if(Quantity is not null | Quantity != string.Empty)
        {
            sb.Append($"{Quantity} ");
        }
        if(Measure is not null | Measure != string.Empty)
        {
            sb.Append($"{Measure} ");
        }
        if(Ingredient is not null)
        {
            sb.Append($"{Ingredient.Name} ");
        }
        if(AdditionalInformation is not null || AdditionalInformation != string.Empty)
        {
            sb.Append($", {AdditionalInformation}");
        }
        return sb.ToString();
    }
}


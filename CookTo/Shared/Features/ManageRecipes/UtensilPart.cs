using CookTo.Shared.Features.ManageUtensils;
using System.Text;

namespace CookTo.Shared.Features.ManageRecipes;

public class UtensilPart
{
    public int RequiredAmount { get; set; }

    public UtensilDto Utensil { get; set; }

    public override string ToString()
    {
        var sb = new StringBuilder();
        if(!(RequiredAmount == 1 || RequiredAmount == 0))
        {
            sb.Append(RequiredAmount.ToString());
            sb.Append(" ");
        }
        sb.Append(Utensil.UtensilName);
        return sb.ToString();
    }
}

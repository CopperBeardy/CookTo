using CookTo.Shared.Modules.ManageUtensils;
using System.Text;

namespace CookTo.Shared.Modules.ManageRecipes;

public class UtensilPart
{
    public int RequiredAmount { get; set; } = 1;

    public Utensil Utensil { get; set; }


    public override string ToString()
    {
        var sb = new StringBuilder();
        if(!(RequiredAmount == 1 || RequiredAmount == 0))
        {
            sb.Append(RequiredAmount);
            sb.Append(' ');
        }
        sb.Append(Utensil.Name);
        return sb.ToString();
    }
}

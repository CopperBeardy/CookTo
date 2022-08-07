using CookTo.Server.Modules.Utensils.Core;

namespace CookTo.Server.Modules.Recipes.Core;

public class UtensilPartDocument
{
    public int RequiredAmount { get; set; }

    public UtensilDocument Utensil { get; set; }
}

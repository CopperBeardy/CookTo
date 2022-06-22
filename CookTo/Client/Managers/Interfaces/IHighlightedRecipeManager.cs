using CookTo.Shared.Modules.ManageRecipes;

namespace CookTo.Client.Managers.Interfaces;

public interface IHighlightedRecipeManager
{
    Task<HighlightedRecipe?> GetHighlighted();
}

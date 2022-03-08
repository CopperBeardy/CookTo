using CookTo.Shared.Features.ManageRecipes;


namespace CookTo.Client.Managers.Interfaces;

public interface IHighlightedRecipeManager
{
    Task<HighlightedRecipeDto> GetHighlighted();
}

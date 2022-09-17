using CookTo.Shared.Models.ManageRecipes;

namespace CookTo.Server.Repositories;

public interface IHighlightedRecipeRepository
{
    Task<Recipe> Get();
}

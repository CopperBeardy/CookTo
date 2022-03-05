
using CookTo.Shared.Features.ManageRecipes;

namespace CookTo.Client.Managers.Interfaces;

public interface IRecipeManager
{
    Task<RecipeDto> GetById(string id);

    Task<RecipeDto> Insert(RecipeDto recipe);

    Task<bool> Update(RecipeDto recipeToUpdate);
}

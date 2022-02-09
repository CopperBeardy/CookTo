using CookTo.Shared.Features.ManageRecipes;

namespace CookTo.Client.Managers.Interfaces;

public interface IRecipeManager
{
    Task<IEnumerable<RecipeDto>> GetAll();

    Task<RecipeDto> GetById(string id);

    Task<RecipeDto> Insert(RecipeDto entity);

    Task<RecipeDto> Update(RecipeDto entityToUpdate);
}

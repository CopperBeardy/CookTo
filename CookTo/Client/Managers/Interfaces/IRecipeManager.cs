using CookTo.Client.Features.ManageRecipes.ViewModel;
using CookTo.Shared.Features.ManageRecipes;

namespace CookTo.Client.Managers.Interfaces;

public interface IRecipeManager
{
    Task<IEnumerable<RecipeDto>> GetAll();

    Task<Recipe> GetById(string id);

    Task<Recipe> Insert(Recipe entity);

    Task<bool> Update(Recipe entityToUpdate);
}

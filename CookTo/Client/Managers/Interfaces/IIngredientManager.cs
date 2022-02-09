using CookTo.Shared.Features.ManageIngredients;

namespace CookTo.Client.Managers.Interfaces;

public interface IIngredientManager
{
    Task<IEnumerable<IngredientDto>> GetAll();

    Task<IngredientDto> GetById(string id);

    Task<string> Insert(IngredientDto entity);

    Task<string> Update(IngredientDto entityToUpdate);
}


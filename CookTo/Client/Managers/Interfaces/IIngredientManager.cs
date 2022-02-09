using CookTo.Shared.Features.ManageIngredients;

namespace CookTo.Client.Managers.Interfaces;

public interface IIngredientManager
{
    Task<IEnumerable<IngredientDto>> GetAll();

    Task<IngredientDto> GetById(string id);

    Task<IngredientDto> Insert(IngredientDto entity);

    Task<IngredientDto> Update(IngredientDto entityToUpdate);
}


using CookTo.Shared.Features.ManageIngredients.Shared;


namespace CookTo.Client.Managers.Interfaces;

public interface IIngredientManager
{
    Task<IEnumerable<IngredientDto>> GetAll();

    Task<IngredientDto> Insert(IngredientDto entity);

    Task<IngredientDto> Update(IngredientDto entityToUpdate);
}


using CookTo.Shared.Features.ManageUtensils;

namespace CookTo.Client.Managers.Interfaces;

public interface IUtensilManager
{
    Task<IEnumerable<UtensilDto>> GetAll();

    Task<UtensilDto> Insert(UtensilDto entity);
}

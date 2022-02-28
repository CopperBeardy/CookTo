using CookTo.Shared.Features.ManageCuisine;

namespace CookTo.Client.Managers.Interfaces;

public interface ICuisineManager
{
    Task<List<CuisineDto>> GetAll();
    Task<CuisineDto> GetById(string id);
    Task<CuisineDto> Insert(CuisineDto entity);
    Task<string> Update(CuisineDto entityToUpdate);
}


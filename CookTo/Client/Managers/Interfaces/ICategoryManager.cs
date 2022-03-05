using CookTo.Shared.Features.ManageCategory;

namespace CookTo.Client.Managers.Interfaces;
public interface ICategoryManager
{
    Task<List<CategoryDto>> GetAll();
    Task<CategoryDto> GetById(string id);
    Task<CategoryDto> Insert(CategoryDto entity);
    Task<string> Update(CategoryDto entityToUpdate);
}


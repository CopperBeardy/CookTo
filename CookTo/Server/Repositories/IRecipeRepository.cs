using CookTo.Shared.Enums;
using CookTo.Shared.Models;

namespace CookTo.Server.Repositories;
public interface IRecipeRepository
{
	Task CreateRecipeAsync(Recipe recipe);
	Task<List<RecipeThumbnail>> GetAllThumbnailsByCategoryAsync(Category category);
}



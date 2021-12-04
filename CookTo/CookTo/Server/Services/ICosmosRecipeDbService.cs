using CookTo.Shared.Models;

namespace CookTo.Server.Services;

public interface ICosmosRecipeDbService
{
    Task<IEnumerable<Recipe>> GetRecipesAsync(string query);
    Task<Recipe> GetRecipeAsync(string recipeId);
    Task AddRecipeAsync(Recipe recipe) ;
    Task UpdateRecipeAsync(string Id, Recipe recipe);
    Task DeleteRecipeAsync(string recipeId);
}

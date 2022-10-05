
using CookTo.Shared.Models.ManageRecipes;

namespace CookTo.Server.Repositories;

public interface IRecipeSummaryRepository
{
    Task<IEnumerable<Recipe>> GetCountAsync(int count = 10);
}

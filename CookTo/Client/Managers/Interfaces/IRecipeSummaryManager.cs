
using CookTo.Shared.Features.ManageRecipes;

namespace CookTo.Client.Managers.Interfaces;

public interface IRecipeSummaryManager
{
    Task<IEnumerable<RecipeSummary>> GetCount(int amount);

    Task<IEnumerable<RecipeSummary>> GetByTerm(string id);
}

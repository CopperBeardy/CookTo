
using CookTo.Shared.Features.ManageRecipes;

namespace CookTo.Client.Managers.Interfaces;

public interface IRecipeSummaryManager
{
    Task<IEnumerable<RecipeSummaryDto>> GetCount(int amount);

    Task<IEnumerable<RecipeSummaryDto>> GetByTerm(string id);
}

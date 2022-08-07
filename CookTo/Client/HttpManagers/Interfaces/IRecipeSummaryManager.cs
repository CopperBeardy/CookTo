using CookTo.Shared.Modules;

namespace CookTo.Client.HTTPManagers.Interfaces;

public interface IRecipeSummaryManager
{
    Task<IEnumerable<RecipeSummary>> GetCount(int amount);

    Task<IEnumerable<RecipeSummary>> GetByTerm(string id);
}

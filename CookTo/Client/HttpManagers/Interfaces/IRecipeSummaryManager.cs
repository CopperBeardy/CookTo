using CookTo.Shared.Modules.ManageRecipes;

namespace CookTo.Client.HttpManagers.Interfaces;

public interface IRecipeSummaryManager
{
    Task<IEnumerable<RecipeSummary>> GetCount(int amount);

    Task<IEnumerable<RecipeSummary>> GetByTerm(string id);
}

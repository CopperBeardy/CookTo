using CookTo.Server.Modules;
using CookTo.Server.Modules.Recipes.Core;
using CookTo.Server.Modules.RecipeSummaries.Core;

namespace CookTo.Server.Modules.RecipeSummaries.Services;

public interface IRecipeSummaryService : IBaseService<RecipeSummaryDocument>
{
    Task<List<RecipeSummaryDocument>> GetAllByTerm(string term, CancellationToken token);

    Task<List<RecipeSummaryDocument>> GetByLimit(int limit, CancellationToken token);
}

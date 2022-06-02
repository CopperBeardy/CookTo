using CookTo.Server.Documents;

namespace CookTo.Server.Services.Interfaces;

public interface IRecipeService : IBaseService<RecipeDocument>
{
    Task<List<RecipeDocument>> GetAllByTerm(string term, CancellationToken token);

    Task<List<RecipeDocument>> GetByLimit(int limit, CancellationToken token);
}

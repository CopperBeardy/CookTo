using CookTo.Server.Documents.RecipeDocument;

namespace CookTo.Server.Services.Interfaces;

public interface IRecipeService : IBaseService<Recipe>
{
    Task<List<Recipe>> GetAllByTerm(string term, CancellationToken token);

    Task<List<Recipe>> GetByLimit(int limit, CancellationToken token);
}

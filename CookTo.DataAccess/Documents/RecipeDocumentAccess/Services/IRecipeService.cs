
namespace CookTo.DataAccess.Documents.RecipeDocumentAccess.Services;

public interface IRecipeService : IBaseService<RecipeDocument>
{
    Task<List<RecipeDocument>> GetSummaries(int count, CancellationToken token, int skip = 0);

    Task<RecipeDocument> GetHighlighted(CancellationToken token);
}

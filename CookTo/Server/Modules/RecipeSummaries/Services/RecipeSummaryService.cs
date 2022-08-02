using CookTo.Server.Modules;
using CookTo.Server.Modules.RecipeSummaries.Core;

namespace CookTo.Server.Modules.RecipeSummaries.Services;

public class RecipeSummaryService : BaseService<RecipeSummaryDocument>, IRecipeSummaryService
{
    public RecipeSummaryService(ICookToDbContext dbContext) : base(dbContext)
    {
    }
    public async Task<List<RecipeSummaryDocument>> GetAllByTerm(string term, CancellationToken token)
    {
        return await DbCollection.Find(
                e => e.Title.Contains(term))
            .ToListAsync(cancellationToken: token);
    }


    public async Task<List<RecipeSummaryDocument>> GetByLimit(int limit, CancellationToken token) => await DbCollection.Find(e => true)
        .Limit(limit)
        .ToListAsync(cancellationToken: token);

    public override async Task<RecipeSummaryDocument> GetByIdAsync(string id, CancellationToken token) => await DbCollection.Find(
        e => e.RecipeId.Equals(id))
        .FirstOrDefaultAsync();

    public override async Task UpdateAsync(RecipeSummaryDocument obj, CancellationToken token) => await DbCollection.ReplaceOneAsync(e => e.RecipeId
        .Equals(obj.RecipeId), obj);

    public override async Task DeleteAsync(string id, CancellationToken token) => await DbCollection.DeleteOneAsync(e => e.RecipeId
        .Equals(id));
}



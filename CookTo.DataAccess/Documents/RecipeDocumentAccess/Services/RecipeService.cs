
using CookTo.DataAccess.DbContext;
using MongoDB.Driver;

namespace CookTo.DataAccess.Documents.RecipeDocumentAccess.Services;

public class RecipeService : BaseService<RecipeDocument>, IRecipeService
{
    public RecipeService(ICookToDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<RecipeDocument> GetHighlighted(CancellationToken token)
    {
        var filter = Builders<RecipeDocument>.Projection
            .Exclude(x => x.Serves)
            .Exclude(x => x.Utensils)
            .Exclude(x => x.CookingSteps)
            .Exclude(x => x.ShoppingItems)
            .Exclude(x => x.Tips);

        var result = await DbCollection.Find(
            e => e.Highlighted == true)
            .Project<RecipeDocument>(filter)
            .FirstOrDefaultAsync();

        return result;
    }

    public async Task<List<RecipeDocument>> GetSummaries(int count, CancellationToken token, int skip = 0)
    {
        var filter = Builders<RecipeDocument>.Projection
            .Exclude(x => x.Description)
            .Exclude(x => x.Serves)
            .Exclude(x => x.Utensils)
            .Exclude(x => x.CookingSteps)
            .Exclude(x => x.ShoppingItems)
            .Exclude(x => x.Tips);

        var result = await DbCollection.Find(
            e => true)
            .Project<RecipeDocument>(filter)
            .Limit(count)
            .Skip(skip)
            .ToListAsync();

        return result;
    }
}



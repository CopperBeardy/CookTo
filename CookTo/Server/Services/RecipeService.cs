using CookTo.Server.Documents;
using CookTo.Server.Services.Interfaces;

namespace CookTo.Server.Services;

public class RecipeService : BaseService<RecipeDocument>, IRecipeService
{
    public RecipeService(ICookToDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<RecipeDocument>> GetAllByTerm(string term, CancellationToken token) => await dbCollection.Find(
        e => e.Title.Contains(term))
        .ToListAsync();

    public async Task<List<RecipeDocument>> GetByLimit(int limit, CancellationToken token) => await dbCollection.Find(e => true)
        .Limit(limit)
        .ToListAsync();
}



using CookTo.Server.Modules;
using CookTo.Server.Modules.Recipes.Core;

namespace CookTo.Server.Modules.Recipes.Services;

public class RecipeService : BaseService<RecipeDocument>, IRecipeService
{
    public RecipeService(ICookToDbContext dbContext) : base(dbContext)
    {
    }
    public async Task<List<RecipeDocument>> GetAllByTerm(string term, CancellationToken token)
    {
        return await DbCollection.Find(
                e => e.Title.Contains(term))
                .ToListAsync(cancellationToken: token);
    }


    public async Task<List<RecipeDocument>> GetByLimit(int limit, CancellationToken token) => await DbCollection.Find(e => true)
        .Limit(limit)
        .ToListAsync(cancellationToken: token);
}



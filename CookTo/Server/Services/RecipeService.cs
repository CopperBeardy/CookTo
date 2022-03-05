using CookTo.Server.Documents.RecipeDocument;
using CookTo.Server.Services.Interfaces;

namespace CookTo.Server.Services;

public class RecipeService : BaseService<Recipe>, IRecipeService
{
    public RecipeService(ICookToDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<Recipe>> GetAllByTerm(string term, CancellationToken token) => await dbCollection.Find(
        e => e.Title.Contains(term))
        .ToListAsync();

    public async Task<List<Recipe>> GetByLimit(int limit, CancellationToken token) => await dbCollection.Find(e => true)
        .Limit(limit)
        .ToListAsync();
}



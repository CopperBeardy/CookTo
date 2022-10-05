using CookTo.Shared.Models;
using CookTo.Shared.Models.ManageCategories;
using CookTo.Shared.Models.ManageRecipes;
using CookTo.Shared.Repositories;
using MongoDB.Driver;
using MongoFramework;
using MongoFramework.Linq;

namespace CookTo.Server.Repositories;

public class RecipeSummaryRepository : IRecipeSummaryRepository
{
    private readonly CookToDbContext context;
    private IMongoCollection<Recipe> dbCollection;

    public RecipeSummaryRepository(CookToDbContext cookToDbContext)
    {
        context = cookToDbContext;
        dbCollection = context.GetCollection<Recipe>(typeof(Recipe).Name);
    }

    public async Task<IEnumerable<Recipe>> GetCountAsync(int count = 10)
    {
        var filter = Builders<Recipe>.Projection
            .Exclude(x => x.Description)
            .Exclude(x => x.Serves)
            .Exclude(x => x.Utensils)
            .Exclude(x => x.CookingSteps)
            .Exclude(x => x.Tips);

        var result = await dbCollection.Find(
            e => true)
            .Project<Recipe>(filter)
            .Limit(count)
            .ToListAsync();

        return result;
    }
}

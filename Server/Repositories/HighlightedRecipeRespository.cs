using CookTo.Shared.Models.ManageRecipes;
using CookTo.Shared.Repositories;
using MongoDB.Driver;

namespace CookTo.Server.Repositories;

public class HighlightedRecipeRepository : IHighlightedRecipeRepository
{
    private readonly CookToDbContext context;
    private IMongoCollection<Recipe> dbCollection;

    public HighlightedRecipeRepository(CookToDbContext cookToDbContext)
    {
        context = cookToDbContext;
        dbCollection = context.GetCollection<Recipe>(typeof(Recipe).Name);
    }

    public async Task<Recipe> Get()
    {
        var filter = Builders<Recipe>.Projection
            .Exclude(x => x.Serves)
            .Exclude(x => x.Utensils)
            .Exclude(x => x.CookingSteps)
            .Exclude(x => x.ShoppingItems)
            .Exclude(x => x.Tips);

        var result = await dbCollection.Find(
            e => e.Highlighted == true)
            .Project<Recipe>(filter)
            .FirstOrDefaultAsync();

        return result;
    }
}

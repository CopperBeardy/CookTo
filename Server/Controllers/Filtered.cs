using CookTo.Shared.Models.ManageRecipes;
using MongoDB.Driver;

namespace CookTo.Server.Controllers;

public class Filtered
{
    //public async Task<Recipe> GetHighlighted(CancellationToken token)
    //{
    //    var filter = Builders<Recipe>.Projection
    //        .Exclude(x => x.Serves)
    //        .Exclude(x => x.Utensils)
    //        .Exclude(x => x.CookingSteps)
    //        .Exclude(x => x.ShoppingItems)
    //        .Exclude(x => x.Tips);

    //    var result = await DbCollection.Find(
    //        e => e.Highlighted == true)
    //        .Project<Recipe>(filter)
    //        .FirstOrDefaultAsync();

    //    return result;
    //}

    //public async Task<List<Recipe>> GetSummaries(int count, CancellationToken token, int skip = 0)
    //{
    //    var filter = Builders<Recipe>.Projection
    //        .Exclude(x => x.Description)
    //        .Exclude(x => x.Serves)
    //        .Exclude(x => x.Utensils)
    //        .Exclude(x => x.CookingSteps)
    //        .Exclude(x => x.ShoppingItems)
    //        .Exclude(x => x.Tips);

    //    var result = await DbCollection.Find(
    //        e => true)
    //        .Project<Recipe>(filter)
    //        .Limit(count)
    //        .Skip(skip)
    //        .ToListAsync();

    //    return result;
    //}
}

using CookTo.Server.Documents.CuisineDocument;
using CookTo.Server.Services.Interfaces;

namespace CookTo.Server.Services;

public class CuisineService : BaseService<Cuisine>, ICuisineService
{
    public CuisineService(ICookToDbContext dbContext) : base(dbContext)
    {
    }

    public async Task Seed()
    {
        var cuisines = new List<Cuisine>()
        {
            new Cuisine() { Name = "British" },
            new Cuisine() { Name = "French" },
            new Cuisine() { Name = "Chinese" },
            new Cuisine() { Name = "Italian" }
        };

        await dbCollection.InsertManyAsync(cuisines);
    }
}
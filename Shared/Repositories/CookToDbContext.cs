using CookTo.Shared.Models.ManageCategories;
using CookTo.Shared.Models.ManageCuisines;
using CookTo.Shared.Models.ManageIngredients;
using CookTo.Shared.Models.ManageRecipes;
using CookTo.Shared.Models.ManageTips;
using CookTo.Shared.Models.ManageUtensils;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoFramework;
using System.Configuration;

namespace CookTo.Shared.Repositories;

public class CookToDbContext
{
    private readonly MongoClient client;
    private readonly IMongoDatabase db;

    public CookToDbContext(IOptions<MongoSettings> configuration)
    {
        client = new MongoClient(configuration.Value.Connection);

        db = client.GetDatabase(configuration.Value.Database);
    }

    public IMongoCollection<T> GetCollection<T>(string name) => db.GetCollection<T>(name);
}

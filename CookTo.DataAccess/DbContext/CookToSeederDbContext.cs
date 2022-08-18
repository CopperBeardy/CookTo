using CookTo.DataAccess.Documents.CategoryDocumentAccess;
using CookTo.DataAccess.Documents.CuisineDocumentAccess;
using CookTo.DataAccess.Documents.IngredientDocumentAccess;
using CookTo.DataAccess.Documents.UtensilDocumentAccess;
using CookTo.DataAccess.SeedDataJson;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CookTo.DataAccess.DbContext;

public class CookToSeederDbContext : ICookToSeederDbContext
{
    private readonly MongoClient client;

    public IClientSessionHandle? Session { get; set; }

    public IMongoDatabase db { get; set; }

    public CookToSeederDbContext(IOptions<MongoSettings> configuration)
    {
        //client = new MongoClient(configuration.Value.Connection);
        //db = client.GetDatabase(configuration.Value.Database);
        client = new MongoClient(configuration.Value.Connection);

        db = client.GetDatabase(configuration.Value.Database);
    }

    public  void HasSeeded(IMongoDatabase db)
    {
        if(!db.ListCollections().Any())
        {
            Seeder.Seed(db);
        }
    }

    public IMongoCollection<T> GetCollection<T>(string name) => db.GetCollection<T>(name);
}


using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CookTo.DataAccess.DbContext;

public class CookToDbContext : ICookToDbContext
{
    private readonly MongoClient client;
    private readonly IMongoDatabase db;

    public CookToDbContext(IOptions<MongoSettings> configuration)
    {
        //client = new MongoClient(configuration.Value.Connection);
        //db = client.GetDatabase(configuration.Value.Database);
        client = new MongoClient(configuration.Value.Connection);

        db = client.GetDatabase(configuration.Value.Database);
    }


    public IMongoCollection<T> GetCollection<T>(string name) => db.GetCollection<T>(name);
}

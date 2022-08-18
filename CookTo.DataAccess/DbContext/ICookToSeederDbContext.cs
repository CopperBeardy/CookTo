using MongoDB.Driver;

namespace CookTo.DataAccess.DbContext;

public interface ICookToSeederDbContext
{
    IMongoDatabase db { get; set; }

    void HasSeeded(IMongoDatabase db);

    IMongoCollection<T> GetCollection<T>(string name);
}

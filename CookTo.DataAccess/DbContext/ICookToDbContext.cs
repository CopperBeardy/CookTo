using MongoDB.Driver;

namespace CookTo.DataAccess.DbContext;

public interface ICookToDbContext
{
    IMongoCollection<T> GetCollection<T>(string name);
}

using MongoDB.Driver;

namespace CookTo.Server.DbContext;
public interface ICookToDbContext
{
	IMongoCollection<T> GetCollection<T>(string name);
}

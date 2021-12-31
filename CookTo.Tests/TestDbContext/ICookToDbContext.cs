namespace CookTo.Tests.TestDbContext;
public interface ICookToDbContext
{
	IMongoCollection<T> GetCollection<T>(string name);
}

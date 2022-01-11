namespace CookTo.Tests.Server.Unit.TestDbContext;
public interface ICookToDbContext
{
	IMongoCollection<T> GetCollection<T>(string name);
}

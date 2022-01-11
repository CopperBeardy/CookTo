using Microsoft.Extensions.Options;
namespace CookTo.Tests.Server.Unit.TestDbContext;
public class CookToDbContext : ICookToDbContext
{
	private readonly IMongoDatabase db;
	private readonly MongoClient client;
	public IClientSessionHandle? session { get; set; }
	public CookToDbContext(IOptions<MongoSettings> configuration)
	{
		client = new MongoClient(configuration.Value.Connection);
		db = client.GetDatabase(configuration.Value.Database);
	}

	public IMongoCollection<T> GetCollection<T>(string name) =>  db.GetCollection<T>(name);
}


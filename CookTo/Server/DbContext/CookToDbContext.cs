using Microsoft.Extensions.Options;

namespace CookTo.Server.DbContext;
public class CookToDbContext : ICookToDbContext
{
	private readonly IMongoDatabase _db;
	private readonly MongoClient _client;
	public IClientSessionHandle session { get; set; }
	public CookToDbContext(IOptions<MongoSettings> configuration)
	{
		_client = new MongoClient(configuration.Value.Connection);
		_db = _client.GetDatabase(configuration.Value.Database);
	}

	public IMongoCollection<T>? GetCollection<T>(string name) => string.IsNullOrEmpty(name) ? null : _db.GetCollection<T>(name);
}

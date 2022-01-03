
using Microsoft.Extensions.Options;

namespace CookTo.Tests.Intergration;

public abstract class Fixture	:IDisposable
{
	public ICookToDbContext cookToDbContext { get; set; }
	public const string connectionString = "mongodb://127.0.0.1:27017/?directConnection=true&serverSelectionTimeoutMS=2000";
	public const string db = "CookTo";
	public string collection;
	public Fixture()
	{
		var settings = new MongoSettings()
		{
			Connection = connectionString,
			Database = db
		};
		IOptions<MongoSettings> options = Options.Create(settings);
		cookToDbContext = new CookToDbContext(options);

	}

	public void SetupCollection(string collectionName)
	{
		collection = collectionName;
		  var client = new MongoClient(connectionString);
		var database = client.GetDatabase(db);
		 database.CreateCollection(collectionName);
	}


	public void Dispose()
	{
		var client = new MongoClient(connectionString);
		var database = client.GetDatabase(db);
		var collections = database.ListCollectionNames().ToList();
		if (collections.Contains(collection))
		{
			database.DropCollection(collection);
		}
	}
}

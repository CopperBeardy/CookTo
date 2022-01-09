
using Microsoft.Extensions.Options;

namespace CookTo.Tests.Intergration;

public abstract class Fixture : IDisposable
{
	public ICookToDbContext CookToDbContext { get; set; }
	public string connectionString = "mongodb://127.0.0.1:27017/?directConnection=true&serverSelectionTimeoutMS=2000";
	public string db = "CookTo";
	public string? collection;
	public Fixture()
	{
		var settings = new MongoSettings(connectionString, db);
		IOptions<MongoSettings> options = Options.Create(settings);
		CookToDbContext = new CookToDbContext(options);

	}

	public void SetupCollection(string collectionName)
	{
		collection = collectionName;
		var client = new MongoClient(connectionString);
		var database = client.GetDatabase(db);
		RemoveCollectionIfExists();
		database.CreateCollection(collection);
	}


	public void Dispose()
	{
		RemoveCollectionIfExists();
		GC.SuppressFinalize(this);
	}

	private void RemoveCollectionIfExists()
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

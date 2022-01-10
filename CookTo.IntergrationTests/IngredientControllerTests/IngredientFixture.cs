

using MongoDB.Driver.Core.Configuration;

namespace CookTo.Tests.Intergration.IngredientControllerTests;

public class IngredientFixture	 : Fixture,IDisposable
{
	public ILogger<IngredientController> logger;
	public IIngredientService ingredientService;
	public IngredientController SUT;
	public List<Ingredient> list;
	public string collectionName = nameof(Ingredient);
	public IngredientFixture()
	{
		var loggerFactory = new LoggerFactory();
		logger = loggerFactory.CreateLogger<IngredientController>();
		ingredientService = new IngredientService(CookToDbContext);
		SUT = new IngredientController(ingredientService, logger);
	}

	public void SetupCollection()
	{
		var client = new MongoClient(connectionString);
		var database = client.GetDatabase(db);
		RemoveCollectionIfExists();
		database.CreateCollection(collectionName);

		var collection = CookToDbContext.GetCollection<Ingredient>(nameof(Ingredient));

		list = new List<Ingredient>() {
		 new Ingredient()
		{
			Name = "Bread"
		},
		 new Ingredient()
		{
			Name = "Milk"
		}
		};

		collection.InsertMany(list);
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
		if (collections.Contains(collectionName))
		{
			database.DropCollection(collectionName);
		}
	}
}



namespace CookTo.Tests.Intergration.IngredientControllerTests;

public class IngredientFixture : Fixture, IDisposable
{
	public ILogger<IngredientController> logger;
	public IIngredientService ingredientService;
	public IngredientController SUT;
	public List<Ingredient> list;
	public IngredientFixture()
	{
		SetupCollection("Ingredient");
		var collection = CookToDbContext.GetCollection<Ingredient>(nameof(Ingredient));
		var loggerFactory = new LoggerFactory();
		logger = loggerFactory.CreateLogger<IngredientController>();
		ingredientService = new IngredientService(CookToDbContext);
		SUT = new IngredientController(ingredientService, logger);

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
}

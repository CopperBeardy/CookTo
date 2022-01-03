

namespace CookTo.Tests.Intergration.IngredientControllerTests;

public class IngredientFixture : Fixture
{
	public ILogger<IngredientController> logger;
	public IIngredientService ingredientService;
	public IngredientController SUT;
	public List<Ingredient> list;
	public IngredientFixture()
	{
		SetupCollection("Ingredient");
		var collection = cookToDbContext.GetCollection<Ingredient>(nameof(Ingredient));
		var loggerFactory = new LoggerFactory();
		logger = loggerFactory.CreateLogger<IngredientController>();
		ingredientService = new IngredientService(cookToDbContext);
		SUT = new IngredientController(ingredientService,logger);

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

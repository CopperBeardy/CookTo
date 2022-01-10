using System.Collections;

namespace CookTo.Tests.Intergration.RecipeControllerTests;

public class RecipeFixture : Fixture, IDisposable
{
	public ILogger<RecipeController> logger;
	public IRecipeService recipeService;
	public RecipeController SUT;
	public List<Recipe> list;
	public string collectionName = nameof(Recipe);
	public RecipeFixture()
	{
		var loggerFactory = new LoggerFactory();
		logger = loggerFactory.CreateLogger<RecipeController>();
		recipeService = new RecipeService(CookToDbContext);
		SUT = new RecipeController(recipeService, logger);

	}


	public void SetupCollection()
	{
		var client = new MongoClient(connectionString);
		var database = client.GetDatabase(db);
		RemoveCollectionIfExists();
		database.CreateCollection(collectionName);

		var collection = CookToDbContext.GetCollection<Recipe>(nameof(Recipe));

		 list = new List<Recipe>() {
			 new Recipe()
			 {
				 Title = "Bread",
				 Category = "Baking",
				 Description = "White Bread loaf recipe with a crisp crust",
				 ImageUrl = "test.png",
				 PrepartionTime = 120,
				 CookingTime = 30,
				 Serves = 4,
				 AuthorId = Guid.NewGuid().ToString(),
				 RecipeParts = new List<RecipePart>()
				 {
					 new RecipePart()
					 {
						 Title = "Loaf",
						 Items = new List<string>()
						 {
							 "500g white bread flour",
							 "7g fast action yeast",
							 "1/2 tsp salt",
							 "300ml luke warm water",
							 "olive oil for kneeding and proofing"
						 }
					 }
				 },
				 CookingSteps = new List<CookingStep>()
				 {
					 new CookingStep()  { StepOrder = 1,Step = "add flour to mixing bowl" },
					 new CookingStep() { StepOrder = 2, Step="add salt to one side of the bowl and yeast to the other side of the bowl" },
					 new CookingStep() { StepOrder = 3, Step="add half the water and mix with fingers, adding water as needed to mop up the flour" },
					 new CookingStep() { StepOrder = 4, Step="spread a little oil on a surface and then add the bread dough" },
					 new CookingStep() { StepOrder = 5, Step="kneed the dough for 5-10 minutes" },
					 new CookingStep() { StepOrder = 6, Step="place dough in a lightly oiled bowl and cover with a damp towel to proof until dough doubled in size" },
					 new CookingStep() { StepOrder = 7, Step="turn dough on to a lightly floured surface and knock back" },
					 new CookingStep() { StepOrder = 8, Step="shape the dough in the shape of a rugby ball and place in loaf tin" },
					 new CookingStep() { StepOrder = 9, Step="place in pre heat oven at 220c for 15 minutes then reduce to 170c for 30 minutes" },
					 new CookingStep() { StepOrder = 10, Step="turn on to wire rack to cool" }
				 },
				 Tips = new List<string>
				 {
					 "when kneeding ensure the dough is covered",
					 "you can use flour to kneed the bread but oil works better for consistency"
				 }
			 },
			 new Recipe()
			 {
				 Title = "Cup  Cakes",
				 Category = "Baking",
				 Description = "Fluffy cup cakes with fun covering",
				 ImageUrl = "test2.png",
				 PrepartionTime = 15,
				 CookingTime = 13,
				 Serves = 12,
				 AuthorId = Guid.NewGuid().ToString(),
				 RecipeParts = new List<RecipePart>()
				 {
					 new RecipePart()
					 {
						 Title = "Vanilla Cup Cakes",
						 Items = new List<string>()
						 {
							 "110g self raising flour",
							 "6 drops of vanilla essence",
							 "110g unsalted butter",
							 "2 eggs",
							 "110g caster sugar"
					}
				}
			},
			CookingSteps = new List<CookingStep>
			{
				new CookingStep()  { StepOrder = 1,Step = "mix butter and sugar until fluffy" },
				new CookingStep() { StepOrder = 2, Step="add vanilla essence" },
				new CookingStep() { StepOrder = 3, Step="fold in the flour" },
				new CookingStep() { StepOrder = 5, Step="bake for 10 minutes or until firm" }
			},
			Tips = new List<string>
			{
				"ensure cakes are firm before removin from oven"
			}
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

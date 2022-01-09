namespace CookTo.Tests.UnitTests.RecipeControllerTests;


public class RecipeFixture
{
	public Mock<IRecipeService> _mockService;
	public Mock<ICookToDbContext> _mockDbContext;
	public Mock<IMongoCollection<Recipe>> _mockCollection;
	public Mock<ILogger<RecipeController>> _mockLogger;
	public RecipeController SUT;
	public Recipe _recipe;
	public List<Recipe> _recipes;
	public RecipeFixture()
	{
		_mockDbContext = new Mock<ICookToDbContext>();
		_mockCollection = new Mock<IMongoCollection<Recipe>>();
		_mockService = new Mock<IRecipeService>();
		_mockLogger = new Mock<ILogger<RecipeController>>();
		_recipes = new List<Recipe>();
		_recipe = new Recipe()
		{
			Id = new ObjectId("1111a2222a3333a4444a5555"),
			Title = "Bread",
			Category = "Baking",
			Description = "White Bread loaf recipe",
			ImageUrl = "test.png",
			PrepartionTime = 120,
			CookingTime = 30,
			Serves = 4,
			AuthorId = "1234a1234b1234c1234d1234",
			RecipeParts = new List<RecipePart>()
			{
				new RecipePart()
				{
					Title = "bread ingredients",
					Items = new List<string>
					{
						"500g white bread flour",
						"7g fast action yeast",
						"1/2 tsp salt",
						"300ml luke warm water",
						"olive oil for kneeding and proofing"
					}
				}
			},
			CookingSteps = new List<CookingStep>
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

		};
		_recipes.Add(_recipe);
		_mockCollection.Object.InsertMany(_recipes);
		_mockDbContext.Setup(c => c.GetCollection<Recipe>(typeof(Recipe).Name)).Returns(_mockCollection.Object);

		SUT = new RecipeController(_mockService.Object, _mockLogger.Object);
	}
}

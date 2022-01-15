using CookTo.Tests.Server.Unit.TestDbContext;

namespace CookTo.Tests.Server.Unit.IngredientControllerTests;

public class IngredientFixture
{
	public Mock<IIngredientService> _mockService;
	public Mock<ICookToDbContext> _mockDbContext;
	public Mock<IMongoCollection<Ingredient>> _mockCollection;
	public Mock<ILogger<IngredientController>> _mockLogger;
	public Ingredient _ingredient;
	public List<Ingredient> _ingredients;
	public IngredientController SUT;

	public IngredientFixture()
	{
		_mockDbContext = new Mock<ICookToDbContext>();
		_mockCollection = new Mock<IMongoCollection<Ingredient>>();
		_mockService = new Mock<IIngredientService>();
		_mockLogger = new Mock<ILogger<IngredientController>>();

		_ingredients = new List<Ingredient>()
		{
			new Ingredient() { Id = "1111a1111b1111c1111d1111", Name = "Cheese" },
			new Ingredient() { Id = "2222a2222b2222c2222d2222", Name = "Flour" }
		};
		_mockCollection.Object.InsertMany(_ingredients);
		_ingredient = new Ingredient() { Id = "3333a3333b3333c3333d3333", Name = "Milk" };
		_mockDbContext.Setup(c => c.GetCollection<Ingredient>(typeof(Ingredient).Name)).Returns(_mockCollection.Object);
		SUT = new IngredientController(_mockService.Object, _mockLogger.Object);
	}
}


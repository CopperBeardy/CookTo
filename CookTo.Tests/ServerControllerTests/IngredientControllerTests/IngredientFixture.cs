using System;
using System.Linq;

namespace CookTo.Tests.ServerControllerTests.IngredientControllerTests;

public class IngredientFixture
{

	public Mock<IIngredientService> _mockService;
	public Mock<ICookToDbContext> _mockDbContext;
	public Mock<IMongoCollection<Ingredient>> _mockCollection;
	public Mock<ILogger<IngredientController>> _mockLogger;
	public Ingredient _ingredient;
	public List<Ingredient> _ingredients;


	public IngredientFixture()
	{
		_mockDbContext = new Mock<ICookToDbContext>();
		_mockCollection = new Mock<IMongoCollection<Ingredient>>();
		_mockService = new Mock<IIngredientService>();
		_mockLogger = new Mock<ILogger<IngredientController>>();

		_ingredients = new List<Ingredient>()
		{
			new Ingredient()
			{
				Id = new ObjectId("1111a1111b1111c1111d1111"),
				Name = "Cheese"
			},
			new Ingredient()
			{
				Id =new ObjectId("2222a2222b2222c2222d2222"),
				Name="Flour"
			}
		};
		_mockCollection.Object.InsertMany(_ingredients);
		_ingredient = new Ingredient()
		{
			Id = new ObjectId("3333a3333b3333c3333d3333"),
			Name = "Milk"
		};
	}
}


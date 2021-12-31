using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookTo.Tests.UnitTests.ServerControllerTests.RecipeControllerTests;


public class RecipeFixture
{
	public Mock<IRecipeService> _mockService;
	public Mock<ICookToDbContext> _mockDbContext;
	public Mock<IMongoCollection<Recipe>> _mockCollection;
	public Mock<ILogger<RecipeController>> _mockLogger;
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
					Ingredients = new List<string>
					{
						"500g white bread flour",
						"7g fast action yeast",
						"1/2 tsp salt",
						"300ml luke warm water",
						"olive oil for kneeding and proofing"
					}
				}
			},
			CookingSteps = new List<string>
			{
				"add flour to mixing bowl",
				"add salt to one side of the bowl and yeast to the other side of the bowl",
				"add half the water and mix with fingers, adding water as needed to mop up the flour",
				"spread a little oil on a surface and then add the bread dough",
				"kneed the dough for 5-10 minutes",
				"place dough in a lightly oiled bowl and cover with a damp towl to proof until dough doubled in size",
				"turn dough on to a lightly floured surface and knock back",
				"shape the dough in the shape of a rugby ball and place in loaf tin",
				"place in pre heat oven at 220c for 15 minutes then reduce to 170c for 30 minutes",
				"turn on to wire rack to cool"
			},
			Tips = new List<string>
			{
				"when kneeding ensure the dough is covered",
				"you can use flour to kneed the bread but oil works better for consistency"
			}

		};
		_recipes.Add(_recipe);
		_mockCollection.Object.InsertMany(_recipes);
	}
}

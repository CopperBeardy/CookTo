namespace CookTo.Tests.Intergration.RecipeControllerTests;

public class Create : RecipeFixture
{

	[Fact]
	public async Task Create_Recipe_OkResult_Success()
	{
		var recipe = new Recipe()
		{
			Title = "Steak Gravy Pie",
			Category = "Baking",
			Description = "steak Pie with puff pastry and vegtables",
			ImageUrl = "test3.png",
			PrepartionTime = 60,
			CookingTime = 240,
			Serves = 4,
			AuthorId = Guid.NewGuid().ToString(),
			RecipeParts = new List<RecipePart>()
				 {
					 new RecipePart()
					 {
						 Title = "filling for pie",
						 Items = new List<string>()
						 {
							 "300g braising steak"
					}
				}
			},
			CookingSteps = new List<CookingStep>
			{
				new CookingStep()  { StepOrder = 1,Step = "mix butter and sugar until fluffy" }
			},
			Tips = new List<string>
			{
				"ensure cakes are firm before removin from oven"
			}
		};
		var result = await SUT.Create(recipe);

		Assert.NotNull(result);

		var obj = Assert.IsAssignableFrom<OkObjectResult>(result.Result);
		var value = Assert.IsType<bool>(obj.Value);
		Assert.True(value);

	}

	[Fact]
	public async Task Create_Recipe_RequiredValueMissing_BadRequestResult_Failure()
	{
		var recipe = new Recipe();

		var result = await SUT.Create(recipe);

		Assert.NotNull(result);
		Assert.IsAssignableFrom<BadRequestResult>(result.Result);
	}

	[Fact]
	public async Task Create_Recipe_LessThanMinLengthValue_BadRequestResult_Failure()
	{
		var recipe = new Recipe()
		{
			Title = "a"
		};

		var result = await SUT.Create(recipe);

		Assert.NotNull(result);
		Assert.IsAssignableFrom<BadRequestResult>(result.Result);
	}



}



namespace CookTo.Tests.Intergration.IngredientControllerTests;

public class Create : IngredientFixture
{
	
	[Fact]
	public async Task Create_Ingredient_OkResult_Success()
	{
		var ingredient = new Ingredient
		{
		   Name = "Flour"
		}; 
		var result = await SUT.Create(ingredient);

		Assert.NotNull(result);

		var obj = Assert.IsAssignableFrom<OkObjectResult>(result.Result);
		var value = Assert.IsType<bool>(obj.Value);
		Assert.True(value);

	}

	[Fact]
	public async Task Create_Ingredient_RequiredValueMissing_BadRequestResult_Failure()
	{
		var ingredient = new Ingredient();
	
		var result = await SUT.Create(ingredient);

		Assert.NotNull(result);	
		Assert.IsAssignableFrom<BadRequestResult>(result.Result);
	}

	[Fact]
	public async Task Create_Ingredient_LessThanMinLengthValue_BadRequestResult_Failure()
	{
		var ingredient = new Ingredient()
		{
			Name = "a"
		};

		var result = await SUT.Create(ingredient);

		Assert.NotNull(result);
		Assert.IsAssignableFrom<BadRequestResult>(result.Result);
	}


}

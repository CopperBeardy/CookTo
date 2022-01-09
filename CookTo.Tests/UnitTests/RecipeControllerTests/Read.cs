using Microsoft.AspNetCore.Mvc;

namespace CookTo.Tests.UnitTests.RecipeControllerTests;

public class Read : RecipeFixture
{
	[Fact]
	public async Task Get_All_Recipes_Success()
	{
		_mockService.Setup(g => g.GetAllAsync()).ReturnsAsync(_recipes);

		Assert.NotNull(SUT);

		var result = await SUT.GetAll();
		var okResult = result.Result as OkObjectResult;
		Assert.NotNull(okResult);
		Assert.IsType<OkObjectResult>(okResult);

		var obj = okResult.Value as List<Recipe>;
		Assert.Single(obj);
	}

	[Fact]
	public async Task Get_All_recipes_ExceptionThrown_Failure()
	{
		_mockService.Setup(g => g.GetAllAsync()).ThrowsAsync(new Exception());

		Assert.NotNull(SUT);

		var result = await SUT.GetAll();
		var notFoundResult = result.Result as NotFoundResult;
		Assert.IsType<NotFoundResult>(notFoundResult);

	}

	[Fact]
	public async Task GetByID_Recipe_Success()
	{
		_mockService.Setup(g => g.GetByIdAsync(It.IsAny<string>())).ReturnsAsync(_recipes.First());

		Assert.NotNull(SUT);

		var result = await SUT.GetById("1111a1111b1111c1111d1111");
		var okResult = result.Result as OkObjectResult;
		Assert.NotNull(okResult);
		Assert.IsType<OkObjectResult>(okResult);

		var obj = okResult.Value as Recipe;
		Assert.Equal("Bread", obj.Title);

		_mockService.Verify(g => g.GetByIdAsync(It.IsAny<string>()), Times.Once());
	}

	[Fact]
	public async Task GetById_Recipe_ExceptionThrown_Failure()
	{
		_mockService.Setup(g => g.GetByIdAsync(It.IsAny<string>())).ThrowsAsync(new Exception());

		Assert.NotNull(SUT);

		var result = await SUT.GetById("1111a1111b1111c1111d1111");
		var notFoundResult = result.Result as NotFoundResult;
		Assert.IsType<NotFoundResult>(notFoundResult);
  	}

	[Theory]
	[InlineData("")]
	[InlineData(null)]
	public async Task GetByID_Recipe_InvalidId_Success(string id)
	{
		Assert.NotNull(SUT);

		var result = await SUT.GetById(id);
		var badRequesstResult = result.Result as BadRequestResult;
		Assert.IsType<BadRequestResult>(badRequesstResult);

		_mockService.Verify(g => g.GetByIdAsync(It.IsAny<string>()), Times.Never());
	}
}

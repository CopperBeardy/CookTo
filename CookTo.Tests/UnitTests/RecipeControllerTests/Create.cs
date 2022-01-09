using Microsoft.AspNetCore.Mvc;

namespace CookTo.Tests.UnitTests.RecipeControllerTests;

public class Create : RecipeFixture
{
	[Fact]
	public async Task InsertRecipe_ValidModel_Success()
	{
		_mockService.Setup(g => g.CreateAsync(It.IsAny<Recipe>())).Returns(Task.CompletedTask);

		Assert.NotNull(SUT);

		var result = await SUT.Create(_recipe);
		var okResult = result.Result as OkObjectResult;
		Assert.IsType<OkObjectResult>(okResult);

		_mockService.Verify(g => g.CreateAsync(It.IsAny<Recipe>()), Times.Once());
	}

	[Fact]
	public async Task InsertRecipe_InValidModel_Failure()
	{
		Assert.NotNull(SUT);
		SUT.ModelState.AddModelError("Title", "Title is required");

		var result = await SUT.Create(new Recipe());
		var badRequestResult = result.Result as BadRequestResult;
		Assert.IsType<BadRequestResult>(badRequestResult);

		_mockService.Verify(g => g.CreateAsync(It.IsAny<Recipe>()), Times.Never());
	}

	[Fact]
	public async Task InsertRecipe_ExceptionThrown_Failure()
	{
		_mockService.Setup(g => g.CreateAsync(It.IsAny<Recipe>())).ThrowsAsync(new Exception());

		Assert.NotNull(SUT);

		var result = await SUT.Create(_recipe);
		var notFoundResult = result.Result as NotFoundResult;
		Assert.IsType<NotFoundResult>(notFoundResult);

	}
}

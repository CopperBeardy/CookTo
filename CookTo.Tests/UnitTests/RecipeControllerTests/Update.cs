using Microsoft.AspNetCore.Mvc;

namespace CookTo.Tests.UnitTests.RecipeControllerTests;

public class Update : RecipeFixture
{
	[Fact]
	public async Task UpdateRecipe_ValidModel_Success()
	{
		var recipe = new Recipe() { Id = new ObjectId("1111a2222a3333a4444a5555"), Title = "White bread" };

		_mockService.Setup(g => g.UpdateAsync(It.IsAny<Recipe>())).Returns(Task.CompletedTask);

		Assert.NotNull(SUT);

		var result = await SUT.Update(recipe);
		var okResult = result.Result as OkObjectResult;
		Assert.IsType<OkObjectResult>(okResult);

		_mockService.Verify(g => g.UpdateAsync(It.IsAny<Recipe>()), Times.Once());
	}

	[Fact]
	public async Task UpdateRecipe_InValidModel_Failure()
	{
		Assert.NotNull(SUT);
		SUT.ModelState.AddModelError("Title", "Title is required");

		var result = await SUT.Update(new Recipe());
		var badRequestResult = result.Result as BadRequestResult;
		Assert.IsType<BadRequestResult>(badRequestResult);

		_mockService.Verify(g => g.UpdateAsync(It.IsAny<Recipe>()), Times.Never());
	}

	[Fact]
	public async Task UpdateRecipe_ExceptionThrown_Failure()
	{
		_mockService.Setup(g => g.UpdateAsync(It.IsAny<Recipe>())).ThrowsAsync(new Exception());
		var recipe = new Recipe() { Id = new ObjectId("1111a2222a3333a4444a5555"), Title = "White bread" };

		Assert.NotNull(SUT);

		var result = await SUT.Update(recipe);
		var notFoundResult = result.Result as NotFoundResult;
		Assert.IsType<NotFoundResult>(notFoundResult);

		_mockLogger.Verify(
			l => l.Log(
				It.Is<LogLevel>(l => l == LogLevel.Error),
				It.IsAny<EventId>(),
				It.Is<It.IsAnyType>(
					(@object, @type) => @object.ToString().Contains("update") && type.Name == "FormattedLogValues"),
				It.IsAny<Exception>(),
				It.IsAny<Func<It.IsAnyType, Exception, string>>()),
			Times.Once());
	}
}

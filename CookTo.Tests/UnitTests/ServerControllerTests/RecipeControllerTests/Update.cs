using Microsoft.AspNetCore.Mvc;

namespace CookTo.Tests.UnitTests.ServerControllerTests.RecipeControllerTests;

public class Update : RecipeFixture
{

	[Fact]
	public async Task UpdateRecipe_ValidModel_Success()
	{
		var recipe = new Recipe()
		{
			Id = new ObjectId("1111a2222a3333a4444a5555"),
			Title = "White bread"
		};

		_mockDbContext.Setup(c => c.GetCollection<Recipe>(typeof(Recipe).Name)).Returns(_mockCollection.Object);
		_mockService.Setup(g => g.UpdateAsync(It.IsAny<Recipe>())).Returns(Task.CompletedTask);

		var sut = new RecipeController(_mockService.Object, _mockLogger.Object);
		Assert.NotNull(sut);

		var result = await sut.Update(recipe);
		var okResult = result.Result as OkObjectResult;
		Assert.IsType<OkObjectResult>(okResult);

		_mockService.Verify(g => g.UpdateAsync(It.IsAny<Recipe>()), Times.Once());
	}

	[Fact]
	public async Task UpdateRecipe_InValidModel_Failure()
	{
		_mockDbContext.Setup(c => c.GetCollection<Recipe>(typeof(Recipe).Name)).Returns(_mockCollection.Object);
		var recipe = new Recipe();

		var sut = new RecipeController(_mockService.Object, _mockLogger.Object);
		Assert.NotNull(sut);
		sut.ModelState.AddModelError("Title", "Title is required");

		var result = await sut.Update(recipe);
		var badRequestResult = result.Result as BadRequestResult;
		Assert.IsType<BadRequestResult>(badRequestResult);

		_mockService.Verify(g => g.UpdateAsync(It.IsAny<Recipe>()), Times.Never());
	}

	[Fact]
	public async Task UpdateRecipe_ExceptionThrown_Failure()
	{
		_mockDbContext.Setup(c => c.GetCollection<Recipe>(typeof(Recipe).Name)).Returns(_mockCollection.Object);
		_mockService.Setup(g => g.UpdateAsync(It.IsAny<Recipe>())).ThrowsAsync(new Exception());

		var sut = new RecipeController(_mockService.Object, _mockLogger.Object);
		Assert.NotNull(sut);
		var recipe = new Recipe()
		{
			Id = new ObjectId("1111a2222a3333a4444a5555"),
			Title = "White bread"
		};
		var result = await sut.Update(recipe);
		var notFoundResult = result.Result as NotFoundResult;
		Assert.IsType<NotFoundResult>(notFoundResult);

		_mockLogger.Verify(l => l.Log(
		 It.Is<LogLevel>(l => l == LogLevel.Error),
		 It.IsAny<EventId>(),
		 It.Is<It.IsAnyType>((@object, @type) => @object.ToString().StartsWith("error occured during") && type.Name == "FormattedLogValues"),
		 It.IsAny<Exception>(),
		 It.IsAny<Func<It.IsAnyType, Exception, string>>()),
		 Times.Once());
	}

}

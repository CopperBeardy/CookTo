using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;

namespace CookTo.Tests.UnitTests.ServerControllerTests.RecipeControllerTests;

public class Create	: RecipeFixture
{
	
		 [Fact]
		 public async Task InsertRecipe_ValidModel_Success()
		{

			_mockDbContext.Setup(c => c.GetCollection<Recipe>(typeof(Recipe).Name)).Returns(_mockCollection.Object);
			_mockService.Setup(g => g.CreateAsync(It.IsAny<Recipe>())).Returns(Task.CompletedTask);

			var sut = new RecipeController(_mockService.Object, _mockLogger.Object);
			Assert.NotNull(sut);

			var result = await sut.Create(_recipe);
			var okResult = result.Result as OkObjectResult;
			Assert.IsType<OkObjectResult>(okResult);

			_mockService.Verify(g => g.CreateAsync(It.IsAny<Recipe>()), Times.Once());
	}

	[Fact]
	public async Task InsertRecipe_InValidModel_Failure()
	{
		_mockDbContext.Setup(c => c.GetCollection<Recipe>(typeof(Recipe).Name)).Returns(_mockCollection.Object);
		var recipe = new Recipe();

		var sut = new RecipeController(_mockService.Object, _mockLogger.Object);
		Assert.NotNull(sut);
		sut.ModelState.AddModelError("Title", "Title is required");

		var result = await sut.Create(recipe);
		var badRequestResult = result.Result as BadRequestResult;
		Assert.IsType<BadRequestResult>(badRequestResult);

		_mockService.Verify(g => g.CreateAsync(It.IsAny<Recipe>()), Times.Never());
	}

	[Fact]
	public async Task InsertRecipe_ExceptionThrown_Failure()
	{
		_mockDbContext.Setup(c => c.GetCollection<Recipe>(typeof(Recipe).Name)).Returns(_mockCollection.Object);
		_mockService.Setup(g => g.CreateAsync(It.IsAny<Recipe>())).ThrowsAsync(new Exception());

		var sut = new RecipeController(_mockService.Object, _mockLogger.Object);
		Assert.NotNull(sut);
	
		var result = await sut.Create(_recipe);
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

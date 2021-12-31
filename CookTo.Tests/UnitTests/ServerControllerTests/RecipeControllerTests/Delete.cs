using Microsoft.AspNetCore.Mvc;

namespace CookTo.Tests.UnitTests.ServerControllerTests.RecipeControllerTests;

public class Delete: RecipeFixture
{
	
	[Fact]
	public async Task Delete_Recipe_Success()
	{
		_mockDbContext.Setup(c => c.GetCollection<Recipe>(typeof(Recipe).Name)).Returns(_mockCollection.Object);
		_mockService.Setup(g => g.DeleteAsync(It.IsAny<string>())).Returns(Task.CompletedTask);

		var sut = new RecipeController(_mockService.Object, _mockLogger.Object);
		Assert.NotNull(sut);

		var result = await sut.Delete("1111a1111b1111c1111d1111");
		var okResult = result.Result as OkObjectResult;
		Assert.NotNull(okResult);
		Assert.IsType<OkObjectResult>(okResult);

		_mockService.Verify(g => g.DeleteAsync(It.IsAny<string>()), Times.Once());
	}

	[Fact]
	public async Task Delete_Recipe_ExceptionThrown_Failure()
	{
		_mockDbContext.Setup(c => c.GetCollection<Recipe>(typeof(Recipe).Name)).Returns(_mockCollection.Object);
		_mockService.Setup(g => g.DeleteAsync(It.IsAny<string>())).ThrowsAsync(new Exception());

		var sut = new RecipeController(_mockService.Object, _mockLogger.Object);
		Assert.NotNull(sut);

		var result = await sut.Delete("1111a1111b1111c1111d1111");
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

	[Theory]
	[InlineData("")]
	[InlineData(null)]
	public async Task Delete_Recipe_InvalidId_Success(string id)
	{
		_mockDbContext.Setup(c => c.GetCollection<Recipe>(typeof(Recipe).Name)).Returns(_mockCollection.Object);

		var sut = new RecipeController(_mockService.Object, _mockLogger.Object);
		Assert.NotNull(sut);

		var result = await sut.Delete(id);
		var badRequestResult = result.Result as BadRequestResult;
		Assert.IsType<BadRequestResult>(badRequestResult);

		_mockService.Verify(g => g.GetByIdAsync(It.IsAny<string>()), Times.Never());
	}

}

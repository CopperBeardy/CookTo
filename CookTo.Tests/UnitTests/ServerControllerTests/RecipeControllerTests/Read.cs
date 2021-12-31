using Microsoft.AspNetCore.Mvc;

namespace CookTo.Tests.UnitTests.ServerControllerTests.RecipeControllerTests;

public class Read : RecipeFixture
{


	[Fact]
	public async Task Get_All_Recipes_Success()
	{
		_mockDbContext.Setup(c => c.GetCollection<Recipe>(typeof(Recipe).Name)).Returns(_mockCollection.Object);
		_mockService.Setup(g => g.GetAllAsync()).ReturnsAsync(_recipes);

		var sut  = new RecipeController(_mockService.Object,_mockLogger.Object);
		Assert.NotNull(sut);

		var result = await sut.GetAll();
		var okResult = result.Result as OkObjectResult;
		Assert.NotNull(okResult);
		Assert.IsType<OkObjectResult>(okResult);

		var obj = okResult.Value as List<Recipe>;
		Assert.Equal(1, obj.Count());
	}

	[Fact]
	public async Task Get_All_recipes_ExceptionThrown_Failure()
	{
		_mockDbContext.Setup(c => c.GetCollection<Recipe>(typeof(Recipe).Name)).Returns(_mockCollection.Object);
		_mockService.Setup(g => g.GetAllAsync()).ThrowsAsync(new Exception());

		var sut = new RecipeController(_mockService.Object, _mockLogger.Object);
		Assert.NotNull(sut);

		var result = await sut.GetAll();
		 var notFoundResult = result.Result as NotFoundResult;
		Assert.IsType<NotFoundResult>(notFoundResult);

		_mockLogger.Verify(l => l.Log(
			It.Is<LogLevel>(l => l == LogLevel.Error),
			It.IsAny<EventId>(),
			It.Is<It.IsAnyType>((@object,@type) => @object.ToString().StartsWith("error occured getting") && type.Name == "FormattedLogValues"),
			It.IsAny<Exception>(),
			It.IsAny<Func<It.IsAnyType,Exception,string>>()),
			Times.Once());
	}

	[Fact]
	public async Task GetByID_Recipe_Success()
	{
		_mockDbContext.Setup(c => c.GetCollection<Recipe>(typeof(Recipe).Name)).Returns(_mockCollection.Object);
		_mockService.Setup(g => g.GetByIdAsync(It.IsAny<string>())).ReturnsAsync(_recipes.First());

		var sut = new RecipeController(_mockService.Object, _mockLogger.Object);
		Assert.NotNull(sut);

		var result = await sut.GetById("1111a1111b1111c1111d1111");
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
		_mockDbContext.Setup(c => c.GetCollection<Recipe>(typeof(Recipe).Name)).Returns(_mockCollection.Object);
		_mockService.Setup(g => g.GetByIdAsync(It.IsAny<string>())).ThrowsAsync(new Exception());

		var sut = new RecipeController(_mockService.Object, _mockLogger.Object);
		Assert.NotNull(sut);

		var result = await sut.GetById("1111a1111b1111c1111d1111");
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
	public async Task GetByID_Recipe_InvalidId_Success(string id)
	{
		_mockDbContext.Setup(c => c.GetCollection<Recipe>(typeof(Recipe).Name)).Returns(_mockCollection.Object);

		var sut = new RecipeController(_mockService.Object, _mockLogger.Object);
		Assert.NotNull(sut);

		var result = await sut.GetById(id);
		var badRequesstResult = result.Result as BadRequestResult;
		Assert.IsType<BadRequestResult>(badRequesstResult);

		_mockService.Verify(g => g.GetByIdAsync(It.IsAny<string>()), Times.Never());
	}

}

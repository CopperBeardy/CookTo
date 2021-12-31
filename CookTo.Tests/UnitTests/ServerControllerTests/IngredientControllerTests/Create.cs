using Microsoft.AspNetCore.Mvc;

namespace CookTo.Tests.UnitTests.ServerControllerTests.IngredientControllerTests;

public class Create : IngredientFixture
{
	
		 [Fact]
		 public async Task InsertIngredient_ValidModel_Success()
		{
			 

			_mockDbContext.Setup(c => c.GetCollection<Ingredient>(typeof(Ingredient).Name)).Returns(_mockCollection.Object);
			_mockService.Setup(g => g.CreateAsync(It.IsAny<Ingredient>())).Returns(Task.CompletedTask);

			var sut = new IngredientController(_mockService.Object, _mockLogger.Object);
			Assert.NotNull(sut);

			var result = await sut.Create(_ingredient);
			var okResult = result.Result as OkObjectResult;
			Assert.IsType<OkObjectResult>(okResult);

		_mockService.Verify(g => g.CreateAsync(It.IsAny<Ingredient>()), Times.Once());
	}

	[Fact]
	public async Task InsertIngredient_InValidModel_Failure()
	{
		_mockDbContext.Setup(c => c.GetCollection<Ingredient>(typeof(Ingredient).Name)).Returns(_mockCollection.Object);
		var ingredient = new Ingredient();

		var sut = new IngredientController(_mockService.Object, _mockLogger.Object);
		Assert.NotNull(sut);
		sut.ModelState.AddModelError("Name", "Name is required");

		var result = await sut.Create(ingredient);
		var badRequestResult = result.Result as BadRequestResult;
		Assert.IsType<BadRequestResult>(badRequestResult);

		_mockService.Verify(g => g.CreateAsync(It.IsAny<Ingredient>()), Times.Never());
	}

	[Fact]
	public async Task InsertIngredient_ExceptionThrown_Failure()
	{
		_mockDbContext.Setup(c => c.GetCollection<Ingredient>(typeof(Ingredient).Name)).Returns(_mockCollection.Object);
		_mockService.Setup(g => g.CreateAsync(It.IsAny<Ingredient>())).ThrowsAsync(new Exception());

		var sut = new IngredientController(_mockService.Object, _mockLogger.Object);
		Assert.NotNull(sut);
		
		var result = await sut.Create(_ingredient);
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

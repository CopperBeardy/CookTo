using Microsoft.AspNetCore.Mvc;

namespace CookTo.Tests.UnitTests.IngredientControllerTests;

public class Create : IngredientFixture
{
	[Fact]
	public async Task InsertIngredient_ValidModel_Success()
	{
		_mockService.Setup(g => g.CreateAsync(It.IsAny<Ingredient>())).Returns(Task.CompletedTask);

		Assert.NotNull(SUT);

		var result = await SUT.Create(_ingredient);
		var okResult = result.Result as OkObjectResult;
		Assert.IsType<OkObjectResult>(okResult);

		_mockService.Verify(g => g.CreateAsync(It.IsAny<Ingredient>()), Times.Once());
	}

	[Fact]
	public async Task InsertIngredient_InValidModel_Failure()
	{
		Assert.NotNull(SUT);
		SUT.ModelState.AddModelError("Name", "Name is required");

		var result = await SUT.Create(new Ingredient());
		var badRequestResult = result.Result as BadRequestResult;
		Assert.IsType<BadRequestResult>(badRequestResult);

		_mockService.Verify(g => g.CreateAsync(It.IsAny<Ingredient>()), Times.Never());
	}

	[Fact]
	public async Task InsertIngredient_ExceptionThrown_Failure()
	{
		_mockService.Setup(g => g.CreateAsync(It.IsAny<Ingredient>())).ThrowsAsync(new Exception());

		Assert.NotNull(SUT);

		var result = await SUT.Create(_ingredient);
		var notFoundResult = result.Result as NotFoundResult;
		Assert.IsType<NotFoundResult>(notFoundResult);

		_mockLogger.Verify(
			l => l.Log(
				It.Is<LogLevel>(l => l == LogLevel.Error),
				It.IsAny<EventId>(),
				It.Is<It.IsAnyType>(
					(@object, @type) => @object.ToString().Contains("insert") && type.Name == "FormattedLogValues"),
				It.IsAny<Exception>(),
				It.IsAny<Func<It.IsAnyType, Exception, string>>()),
			Times.Once());
	}
}

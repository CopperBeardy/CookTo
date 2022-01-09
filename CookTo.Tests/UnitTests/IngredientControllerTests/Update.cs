using Microsoft.AspNetCore.Mvc;

namespace CookTo.Tests.UnitTests.IngredientControllerTests;

public class Update : IngredientFixture
{
	[Fact]
	public async Task UpdateIngredient_ValidModel_Success()
	{
		var ingredient = new Ingredient() { Id = new ObjectId("1111a1111b1111c1111d1111"), Name = "Cheddar Cheese" };

		_mockService.Setup(g => g.UpdateAsync(It.IsAny<Ingredient>())).Returns(Task.CompletedTask);

		Assert.NotNull(SUT);

		var result = await SUT.Update(ingredient);
		var okResult = result.Result as OkObjectResult;
		Assert.IsType<OkObjectResult>(okResult);

		_mockService.Verify(g => g.UpdateAsync(It.IsAny<Ingredient>()), Times.Once());
	}

	[Fact]
	public async Task UpdateIngredient_InValidModel_Failure()
	{
		Assert.NotNull(SUT);
		SUT.ModelState.AddModelError("Name", "Name is required");

		var result = await SUT.Update(new Ingredient());
		var badRequestResult = result.Result as BadRequestResult;
		Assert.IsType<BadRequestResult>(badRequestResult);

		_mockService.Verify(g => g.UpdateAsync(It.IsAny<Ingredient>()), Times.Never());
	}

	[Fact]
	public async Task UpdateIngredient_ExceptionThrown_Failure()
	{
		_mockService.Setup(g => g.UpdateAsync(It.IsAny<Ingredient>())).ThrowsAsync(new Exception());
		var ingredient = new Ingredient() { Id = new ObjectId("1111a1111b1111c1111d1111"), Name = "Cheddar Cheese" };

		Assert.NotNull(SUT);

		var result = await SUT.Update(ingredient);
		var notFoundResult = result.Result as NotFoundResult;
		Assert.IsType<NotFoundResult>(notFoundResult);

	}
}

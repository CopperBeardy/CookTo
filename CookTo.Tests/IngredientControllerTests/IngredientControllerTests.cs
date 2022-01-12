using Microsoft.AspNetCore.Mvc;

namespace CookTo.Tests.Server.Unit.IngredientControllerTests;

public class IngredientControllerTests : IngredientFixture
{
	[Fact]
	public async Task GetAll_Ingredients_OkResult()
	{
		_mockService.Setup(g => g.GetAllAsync()).ReturnsAsync(_ingredients);

		Assert.NotNull(SUT);

		var result = await SUT.GetAllAsync();
		var okResult = result.Result as OkObjectResult;
		Assert.NotNull(okResult);
		Assert.IsType<OkObjectResult>(okResult);

		var obj = okResult.Value as List<Ingredient>;
		Assert.Equal(2, obj.Count);
	}

	[Fact]
	public async Task GetAll_Ingredients_ExceptionThrown_NotFoundResult()
	{
		_mockService.Setup(g => g.GetAllAsync()).ThrowsAsync(new Exception());

		Assert.NotNull(SUT);

		var result = await SUT.GetAllAsync();
		var notFoundResult = result.Result as NotFoundResult;
		Assert.IsType<NotFoundResult>(notFoundResult);
	}

	[Fact]
	public async Task GetByID_Ingredient_ValidId_OkResult()
	{
		_mockService.Setup(g => g.GetByIdAsync(It.IsAny<string>())).ReturnsAsync(_ingredients.First());

		Assert.NotNull(SUT);

		var result = await SUT.GetByIdAsync("1111a1111b1111c1111d1111");
		var okResult = result.Result as OkObjectResult;
		Assert.NotNull(okResult);
		Assert.IsType<OkObjectResult>(okResult);

		var obj = okResult.Value as Ingredient;
		Assert.Equal("Cheese", obj.Name);

		_mockService.Verify(g => g.GetByIdAsync(It.IsAny<string>()), Times.Once());
	}

	[Fact]
	public async Task GetById_Ingredient_ExceptionThrown_NotFoundResult()
	{
		_mockService.Setup(g => g.GetByIdAsync(It.IsAny<string>())).ThrowsAsync(new Exception());

		Assert.NotNull(SUT);

		var result = await SUT.GetByIdAsync("1111a1111b1111c1111d1111");
		var notFoundResult = result.Result as NotFoundResult;
		Assert.IsType<NotFoundResult>(notFoundResult);
	}

	[Theory]
	[InlineData("")]
	[InlineData(null)]
	public async Task GetByID_Ingredient_InvalidId_OkResult(string id)
	{
		Assert.NotNull(SUT);

		var result = await SUT.GetByIdAsync(id);
		var badRequesstResult = result.Result as BadRequestResult;
		Assert.IsType<BadRequestResult>(badRequesstResult);

		_mockService.Verify(g => g.GetByIdAsync(It.IsAny<string>()), Times.Never());
	}

	[Fact]
	public async Task Insert_Ingredient_ValidModel_OkResult()
	{
		_mockService.Setup(g => g.CreateAsync(It.IsAny<Ingredient>())).Returns(Task.CompletedTask);

		Assert.NotNull(SUT);

		var result = await SUT.CreateAsync(_ingredient);
		var okResult = result.Result as OkObjectResult;
		Assert.IsType<OkObjectResult>(okResult);

		_mockService.Verify(g => g.CreateAsync(It.IsAny<Ingredient>()), Times.Once());
	}

	[Fact]
	public async Task Insert_Ingredient_InValidModel_BadRequestResult()
	{
		Assert.NotNull(SUT);
		SUT.ModelState.AddModelError("Name", "Name is required");

		var result = await SUT.CreateAsync(new Ingredient());
		var badRequestResult = result.Result as BadRequestResult;
		Assert.IsType<BadRequestResult>(badRequestResult);

		_mockService.Verify(g => g.CreateAsync(It.IsAny<Ingredient>()), Times.Never());
	}

	[Fact]
	public async Task Insert_Ingredient_ExceptionThrown_NotFoundResult()
	{
		_mockService.Setup(g => g.CreateAsync(It.IsAny<Ingredient>())).ThrowsAsync(new Exception());

		Assert.NotNull(SUT);

		var result = await SUT.CreateAsync(_ingredient);
		var notFoundResult = result.Result as NotFoundResult;
		Assert.IsType<NotFoundResult>(notFoundResult);
	}

	[Fact]
	public async Task Delete_Ingredient_OKResult()
	{
		_mockService.Setup(g => g.DeleteAsync(It.IsAny<string>())).Returns(Task.CompletedTask);

		Assert.NotNull(SUT);

		var result = await SUT.DeleteAsync("1111a1111b1111c1111d1111");
		var okResult = result.Result as OkObjectResult;
		Assert.NotNull(okResult);
		Assert.IsType<OkObjectResult>(okResult);

		_mockService.Verify(g => g.DeleteAsync(It.IsAny<string>()), Times.Once());
	}

	[Fact]
	public async Task Delete_Ingredient_ExceptionThrown_NotFoundResult()
	{
		_mockService.Setup(g => g.DeleteAsync(It.IsAny<string>())).ThrowsAsync(new Exception());

		Assert.NotNull(SUT);

		var result = await SUT.DeleteAsync("1111a1111b1111c1111d1111");
		var notFoundResult = result.Result as NotFoundResult;
		Assert.IsType<NotFoundResult>(notFoundResult);
	}

	[Theory]
	[InlineData("")]
	[InlineData(null)]
	public async Task Delete_Ingredient_InvalidId_BadRequestResult(string id)
	{
		Assert.NotNull(SUT);

		var result = await SUT.DeleteAsync(id);
		var badRequestResult = result.Result as BadRequestResult;
		Assert.IsType<BadRequestResult>(badRequestResult);

		_mockService.Verify(g => g.GetByIdAsync(It.IsAny<string>()), Times.Never());
	}

	[Fact]
	public async Task Update_Ingredient_ValidModel_OKResult()
	{
		var ingredient = new Ingredient() { Id = new ObjectId("1111a1111b1111c1111d1111"), Name = "Cheddar Cheese" };

		_mockService.Setup(g => g.UpdateAsync(It.IsAny<Ingredient>())).Returns(Task.CompletedTask);

		Assert.NotNull(SUT);

		var result = await SUT.UpdateAsync(ingredient);
		var okResult = result.Result as OkObjectResult;
		Assert.IsType<OkObjectResult>(okResult);

		_mockService.Verify(g => g.UpdateAsync(It.IsAny<Ingredient>()), Times.Once());
	}

	[Fact]
	public async Task Update_Ingredient_InValidModel_BadRequestResult()
	{
		Assert.NotNull(SUT);
		SUT.ModelState.AddModelError("Name", "Name is required");

		var result = await SUT.UpdateAsync(new Ingredient());
		var badRequestResult = result.Result as BadRequestResult;
		Assert.IsType<BadRequestResult>(badRequestResult);

		_mockService.Verify(g => g.UpdateAsync(It.IsAny<Ingredient>()), Times.Never());
	}

	[Fact]
	public async Task Update_Ingredient_ExceptionThrown_NotFoundResult()
	{
		_mockService.Setup(g => g.UpdateAsync(It.IsAny<Ingredient>())).ThrowsAsync(new Exception());
		var ingredient = new Ingredient() { Id = new ObjectId("1111a1111b1111c1111d1111"), Name = "Cheddar Cheese" };

		Assert.NotNull(SUT);

		var result = await SUT.UpdateAsync(ingredient);
		var notFoundResult = result.Result as NotFoundResult;
		Assert.IsType<NotFoundResult>(notFoundResult);
	}
}

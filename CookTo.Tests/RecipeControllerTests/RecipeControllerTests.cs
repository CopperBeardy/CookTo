using Microsoft.AspNetCore.Mvc;

namespace CookTo.Tests.Server.Unit.RecipeControllerTests;

public class RecipeControllerTests : RecipeFixture
{
	[Fact]
	public async Task GetAll_Recipes_OKResult()
	{
		_mockService.Setup(g => g.GetAllAsync()).ReturnsAsync(_recipes);

		Assert.NotNull(SUT);

		var result = await SUT.GetAllAsync();
		var okResult = result.Result as OkObjectResult;
		Assert.NotNull(okResult);
		Assert.IsType<OkObjectResult>(okResult);

		var obj = okResult.Value as List<Recipe>;
		Assert.Single(obj);
	}

	[Fact]
	public async Task GetAll_Recipes_ExceptionThrown_NotFoundResult()
	{
		_mockService.Setup(g => g.GetAllAsync()).ThrowsAsync(new Exception());

		Assert.NotNull(SUT);

		var result = await SUT.GetAllAsync();
		var notFoundResult = result.Result as NotFoundResult;
		Assert.IsType<NotFoundResult>(notFoundResult);
	}

	[Fact]
	public async Task GetByID_Recipe_OkResult()
	{
		_mockService.Setup(g => g.GetByIdAsync(It.IsAny<string>())).ReturnsAsync(_recipes.First());

		Assert.NotNull(SUT);

		var result = await SUT.GetByIdAsync("1111a1111b1111c1111d1111");
		var okResult = result.Result as OkObjectResult;
		Assert.NotNull(okResult);
		Assert.IsType<OkObjectResult>(okResult);

		var obj = okResult.Value as Recipe;
		Assert.Equal("Bread", obj.Title);

		_mockService.Verify(g => g.GetByIdAsync(It.IsAny<string>()), Times.Once());
	}

	[Fact]
	public async Task GetById_Recipe_ExceptionThrown_OkResult()
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
	public async Task GetByID_Recipe_InvalidId_BadRequestResult(string id)
	{
		Assert.NotNull(SUT);

		var result = await SUT.GetByIdAsync(id);
		var badRequestResult = result.Result as BadRequestResult;
		Assert.IsType<BadRequestResult>(badRequestResult);

		_mockService.Verify(g => g.GetByIdAsync(It.IsAny<string>()), Times.Never());
	}

	[Fact(Skip = "true")]
	public async Task Insert_Recipe_ValidModel_OkResult()
	{
		_mockService.Setup(g => g.CreateAsync(It.IsAny<Recipe>())).Returns(Task.CompletedTask);

		Assert.NotNull(SUT);

		var result = await SUT.CreateAsync(_recipe);
		var okResult = result.Result as OkObjectResult;
		Assert.IsType<OkObjectResult>(okResult);

		_mockService.Verify(g => g.CreateAsync(It.IsAny<Recipe>()), Times.Once());
	}

	[Fact]
	public async Task Insert_Recipe_InValidModel_BadRequestResult()
	{
		Assert.NotNull(SUT);
		SUT.ModelState.AddModelError("Title", "Title is required");

		var result = await SUT.CreateAsync(new Recipe());
		var badRequestResult = result.Result as BadRequestResult;
		Assert.IsType<BadRequestResult>(badRequestResult);

		_mockService.Verify(g => g.CreateAsync(It.IsAny<Recipe>()), Times.Never());
	}

	[Fact(Skip = "true")]
	public async Task Insert_Recipe_ExceptionThrown_NotFoundResult()
	{
		_mockService.Setup(g => g.CreateAsync(It.IsAny<Recipe>())).ThrowsAsync(new Exception());

		Assert.NotNull(SUT);

		var result = await SUT.CreateAsync(_recipe);
		var notFoundResult = result.Result as NotFoundResult;
		Assert.IsType<NotFoundResult>(notFoundResult);
	}

	[Fact]
	public async Task Delete_Recipe_ValidId_OkResult()
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
	public async Task Delete_Recipe_ExceptionThrown_NotFoundResult()
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
	public async Task Delete_Recipe_InvalidId_BadRequestResult(string id)
	{
		Assert.NotNull(SUT);

		var result = await SUT.DeleteAsync(id);
		var badRequestResult = result.Result as BadRequestResult;
		Assert.IsType<BadRequestResult>(badRequestResult);

		_mockService.Verify(g => g.GetByIdAsync(It.IsAny<string>()), Times.Never());
	}

	[Fact(Skip = "true")]
	public async Task Update_Recipe_ValidModel_OKResult()
	{
		var recipe = new Recipe() { Id = new ObjectId("1111a2222a3333a4444a5555"), Title = "White bread" };

		_mockService.Setup(g => g.UpdateAsync(It.IsAny<Recipe>())).Returns(Task.CompletedTask);

		Assert.NotNull(SUT);

		var result = await SUT.UpdateAsync(recipe);
		var okResult = result.Result as OkObjectResult;
		Assert.IsType<OkObjectResult>(okResult);

		_mockService.Verify(g => g.UpdateAsync(It.IsAny<Recipe>()), Times.Once());
	}

	[Fact]
	public async Task Update_Recipe_InValidModel_BadRequestResult()
	{
		Assert.NotNull(SUT);
		SUT.ModelState.AddModelError("Title", "Title is required");

		var result = await SUT.UpdateAsync(new Recipe());
		var badRequestResult = result.Result as BadRequestResult;
		Assert.IsType<BadRequestResult>(badRequestResult);

		_mockService.Verify(g => g.UpdateAsync(It.IsAny<Recipe>()), Times.Never());
	}
}

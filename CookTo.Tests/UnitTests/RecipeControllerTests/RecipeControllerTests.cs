using Microsoft.AspNetCore.Mvc;

namespace CookTo.Tests.UnitTests.RecipeControllerTests;

public class RecipeControllerTests : RecipeFixture
{
	[Fact]
	public async Task Get_All_Recipes_Success()
	{
		_mockService.Setup(g => g.GetAllAsync()).ReturnsAsync(_recipes);

		Assert.NotNull(SUT);

		var result = await SUT.GetAll();
		var okResult = result.Result as OkObjectResult;
		Assert.NotNull(okResult);
		Assert.IsType<OkObjectResult>(okResult);

		var obj = okResult.Value as List<Recipe>;
		Assert.Single(obj);
	}

	[Fact]
	public async Task Get_All_recipes_ExceptionThrown_Failure()
	{
		_mockService.Setup(g => g.GetAllAsync()).ThrowsAsync(new Exception());

		Assert.NotNull(SUT);

		var result = await SUT.GetAll();
		var notFoundResult = result.Result as NotFoundResult;
		Assert.IsType<NotFoundResult>(notFoundResult);

	}

	[Fact]
	public async Task GetByID_Recipe_Success()
	{
		_mockService.Setup(g => g.GetByIdAsync(It.IsAny<string>())).ReturnsAsync(_recipes.First());

		Assert.NotNull(SUT);

		var result = await SUT.GetById("1111a1111b1111c1111d1111");
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
		_mockService.Setup(g => g.GetByIdAsync(It.IsAny<string>())).ThrowsAsync(new Exception());

		Assert.NotNull(SUT);

		var result = await SUT.GetById("1111a1111b1111c1111d1111");
		var notFoundResult = result.Result as NotFoundResult;
		Assert.IsType<NotFoundResult>(notFoundResult);
	}

	[Theory]
	[InlineData("")]
	[InlineData(null)]
	public async Task GetByID_Recipe_InvalidId_Success(string id)
	{
		Assert.NotNull(SUT);

		var result = await SUT.GetById(id);
		var badRequesstResult = result.Result as BadRequestResult;
		Assert.IsType<BadRequestResult>(badRequesstResult);

		_mockService.Verify(g => g.GetByIdAsync(It.IsAny<string>()), Times.Never());
	}

	[Fact(Skip = "true")]
	public async Task InsertRecipe_ValidModel_Success()
	{
		_mockService.Setup(g => g.CreateAsync(It.IsAny<Recipe>())).Returns(Task.CompletedTask);

		Assert.NotNull(SUT);

		var result = await SUT.Create(_recipe);
		var okResult = result.Result as OkObjectResult;
		Assert.IsType<OkObjectResult>(okResult);

		_mockService.Verify(g => g.CreateAsync(It.IsAny<Recipe>()), Times.Once());
	}

	[Fact]
	public async Task InsertRecipe_InValidModel_Failure()
	{
		Assert.NotNull(SUT);
		SUT.ModelState.AddModelError("Title", "Title is required");

		var result = await SUT.Create(new Recipe());
		var badRequestResult = result.Result as BadRequestResult;
		Assert.IsType<BadRequestResult>(badRequestResult);

		_mockService.Verify(g => g.CreateAsync(It.IsAny<Recipe>()), Times.Never());
	}

	[Fact(Skip = "true")]
	public async Task InsertRecipe_ExceptionThrown_Failure()
	{
		_mockService.Setup(g => g.CreateAsync(It.IsAny<Recipe>())).ThrowsAsync(new Exception());
		
		Assert.NotNull(SUT);

		var result = await SUT.Create(_recipe);
		var notFoundResult = result.Result as NotFoundResult;
		Assert.IsType<NotFoundResult>(notFoundResult);

	}
	[Fact]
	public async Task Delete_Recipe_Success()
	{
		_mockService.Setup(g => g.DeleteAsync(It.IsAny<string>())).Returns(Task.CompletedTask);

		Assert.NotNull(SUT);

		var result = await SUT.Delete("1111a1111b1111c1111d1111");
		var okResult = result.Result as OkObjectResult;
		Assert.NotNull(okResult);
		Assert.IsType<OkObjectResult>(okResult);

		_mockService.Verify(g => g.DeleteAsync(It.IsAny<string>()), Times.Once());
	}

	[Fact]
	public async Task Delete_Recipe_ExceptionThrown_Failure()
	{
		_mockService.Setup(g => g.DeleteAsync(It.IsAny<string>())).ThrowsAsync(new Exception());

		Assert.NotNull(SUT);

		var result = await SUT.Delete("1111a1111b1111c1111d1111");
		var notFoundResult = result.Result as NotFoundResult;
		Assert.IsType<NotFoundResult>(notFoundResult);

	}

	[Theory]
	[InlineData("")]
	[InlineData(null)]
	public async Task Delete_Recipe_InvalidId_Success(string id)
	{
		Assert.NotNull(SUT);

		var result = await SUT.Delete(id);
		var badRequestResult = result.Result as BadRequestResult;
		Assert.IsType<BadRequestResult>(badRequestResult);

		_mockService.Verify(g => g.GetByIdAsync(It.IsAny<string>()), Times.Never());
	}

	[Fact(Skip ="true")]
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



}

using Microsoft.AspNetCore.Mvc;

namespace CookTo.Tests.Server.Unit.BookmarkControllerTests;

public class BookmarkControllerTests : BookmarksFixture
{
	[Fact]
	public async Task Insert_Bookmarks_ValidModel_OkResult()
	{
		_mockService.Setup(g => g.CreateAsync(It.IsAny<Bookmarks>())).Returns(Task.CompletedTask);

		Assert.NotNull(SUT);

		var result = await SUT.CreateAsync(_bookmarks);
		var okResult = result.Result as OkObjectResult;
		Assert.IsType<OkObjectResult>(okResult);

		_mockService.Verify(g => g.CreateAsync(It.IsAny<Bookmarks>()), Times.Once());
	}

	[Fact]
	public async Task Insert_Bookmarks_InValidModel_BadRequestResult()
	{
		Assert.NotNull(SUT);
		SUT.ModelState.AddModelError("Name", "Name is required");

		var result = await SUT.CreateAsync(new Bookmarks());
		var badRequestResult = result.Result as BadRequestResult;
		Assert.IsType<BadRequestResult>(badRequestResult);

		_mockService.Verify(g => g.CreateAsync(It.IsAny<Bookmarks>()), Times.Never());
	}

	[Fact]
	public async Task Insert_Bookmarks_ExceptionThrown_NotFoundResult()
	{
		_mockService.Setup(g => g.CreateAsync(It.IsAny<Bookmarks>())).ThrowsAsync(new Exception());

		Assert.NotNull(SUT);

		var result = await SUT.CreateAsync(_bookmarks);
		var notFoundResult = result.Result as NotFoundResult;
		Assert.IsType<NotFoundResult>(notFoundResult);
	}

	[Fact]
	public async Task Delete_Bookmarks_ValidId_OKResult()
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
	public async Task Delete_Bookmarks_ExceptionThrown_NotFoundResult()
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
	public async Task Delete_Bookmarks_InvalidId_OkResult(string id)
	{
		Assert.NotNull(SUT);

		var result = await SUT.DeleteAsync(id);
		var badRequestResult = result.Result as BadRequestResult;
		Assert.IsType<BadRequestResult>(badRequestResult);

		_mockService.Verify(g => g.GetByIdAsync(It.IsAny<string>()), Times.Never());
	}

	[Fact]
	public async Task GetByUserID_Bookmarks_OkResult()
	{
		_mockService.Setup(g => g.GetByUserIdAsync(It.IsAny<string>())).ReturnsAsync(_bookmarks);

		Assert.NotNull(SUT);

		var result = await SUT.GetByUserIdAsync("1111a1111b1111c1111d1111");
		var okResult = result.Result as OkObjectResult;
		Assert.NotNull(okResult);
		Assert.IsType<OkObjectResult>(okResult);

		var obj = okResult.Value as Bookmarks;
		Assert.Equal(_bookmarks.UserId, obj.UserId);

		_mockService.Verify(g => g.GetByUserIdAsync(It.IsAny<string>()), Times.Once());
	}

	[Fact]
	public async Task GetByUserIdAsync_Bookmarks_ExceptionThrown_NotFoundResult()
	{
		_mockService.Setup(g => g.GetByUserIdAsync(It.IsAny<string>())).ThrowsAsync(new Exception());

		Assert.NotNull(SUT);

		var result = await SUT.GetByUserIdAsync("1111a1111b1111c1111d1111");
		var notFoundResult = result.Result as NotFoundResult;
		Assert.IsType<NotFoundResult>(notFoundResult);
	}

	[Theory]
	[InlineData("")]
	[InlineData(null)]
	public async Task GetByID_Bookmarks_InvalidId_OkResult(string id)
	{
		Assert.NotNull(SUT);

		var result = await SUT.GetByUserIdAsync(id);
		var badRequesstResult = result.Result as BadRequestResult;
		Assert.IsType<BadRequestResult>(badRequesstResult);

		_mockService.Verify(g => g.GetByIdAsync(It.IsAny<string>()), Times.Never());
	}

	[Fact]
	public async Task Update_Bookmarks_ValidModel_OKResult()
	{
		var Bookmarked = new Bookmarked()
		{
			RecipeId = new ObjectId("1111a1111b1111c1111d1111"),
			Title = "Cheddar Cheese"
		};
		_bookmarks.BookmarkedRecipes.Add(Bookmarked);
		_mockService.Setup(g => g.UpdateAsync(It.IsAny<Bookmarks>())).Returns(Task.CompletedTask);

		Assert.NotNull(SUT);

		var result = await SUT.UpdateAsync(_bookmarks);
		var okResult = result.Result as OkObjectResult;
		Assert.IsType<OkObjectResult>(okResult);

		_mockService.Verify(g => g.UpdateAsync(It.IsAny<Bookmarks>()), Times.Once());
	}

	[Fact]
	public async Task Update_Bookmarks_InValidModel_BadRequestResult()
	{
		Assert.NotNull(SUT);
		SUT.ModelState.AddModelError("userid", "userid is required");

		var result = await SUT.UpdateAsync(new Bookmarks());
		var badRequestResult = result.Result as BadRequestResult;
		Assert.IsType<BadRequestResult>(badRequestResult);

		_mockService.Verify(g => g.UpdateAsync(It.IsAny<Bookmarks>()), Times.Never());
	}

	[Fact]
	public async Task Update_Bookmarks_ExceptionThrown_NotFoundResult()
	{
		var Bookmarked = new Bookmarked()
		{
			RecipeId = new ObjectId("1111a1111b1111c1111d1111"),
			Title = "Cheddar Cheese"
		};
		_bookmarks.BookmarkedRecipes.Add(Bookmarked);

		_mockService.Setup(g => g.UpdateAsync(It.IsAny<Bookmarks>())).ThrowsAsync(new Exception());

		Assert.NotNull(SUT);

		var result = await SUT.UpdateAsync(_bookmarks);
		var notFoundResult = result.Result as NotFoundResult;
		Assert.IsType<NotFoundResult>(notFoundResult);
	}
}

using Microsoft.AspNetCore.Mvc;

namespace CookTo.Tests.UnitTests.BookmarkControllerTests;

public class Update : BookmarksFixture
{
	[Fact]
	public async Task UpdateBookmarks_ValidModel_Success()
	{
		var Bookmarked = new Bookmarked()
		{
			RecipeId = new ObjectId("1111a1111b1111c1111d1111"),
			Title = "Cheddar Cheese"
		};
		_bookmarks.BookmarkedRecipes.Add(Bookmarked);
		_mockService.Setup(g => g.UpdateAsync(It.IsAny<Bookmarks>())).Returns(Task.CompletedTask);

		Assert.NotNull(SUT);

		var result = await SUT.Update(_bookmarks);
		var okResult = result.Result as OkObjectResult;
		Assert.IsType<OkObjectResult>(okResult);

		_mockService.Verify(g => g.UpdateAsync(It.IsAny<Bookmarks>()), Times.Once());
	}

	[Fact]
	public async Task UpdateBookmarks_InValidModel_Failure()
	{
		Assert.NotNull(SUT);
		SUT.ModelState.AddModelError("userid", "userid is required");

		var result = await SUT.Update(new Bookmarks());
		var badRequestResult = result.Result as BadRequestResult;
		Assert.IsType<BadRequestResult>(badRequestResult);

		_mockService.Verify(g => g.UpdateAsync(It.IsAny<Bookmarks>()), Times.Never());
	}

	[Fact]
	public async Task UpdateBookmarks_ExceptionThrown_Failure()
	{
		var Bookmarked = new Bookmarked()
		{
			RecipeId = new ObjectId("1111a1111b1111c1111d1111"),
			Title = "Cheddar Cheese"
		};
		_bookmarks.BookmarkedRecipes.Add(Bookmarked);

		_mockService.Setup(g => g.UpdateAsync(It.IsAny<Bookmarks>())).ThrowsAsync(new Exception());

		Assert.NotNull(SUT);

		var result = await SUT.Update(_bookmarks);
		var notFoundResult = result.Result as NotFoundResult;
		Assert.IsType<NotFoundResult>(notFoundResult);

	
	}
}

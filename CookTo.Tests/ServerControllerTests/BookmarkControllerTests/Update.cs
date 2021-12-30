using Microsoft.AspNetCore.Mvc;

namespace CookTo.Tests.ServerControllerTests.BookmarkControllerTests;

public class Update : BookmarksFixture
{

	[Fact]
	public async Task UpdateBookmarks_ValidModel_Success()
	{
		var Bookmarked= new Bookmarked()
		{
			RecipeId = new ObjectId("1111a1111b1111c1111d1111"),
			 Title = "Cheddar Cheese"
		};
		_bookmarks.BookmarkedRecipes.Add(Bookmarked);
		_mockDbContext.Setup(c => c.GetCollection<Bookmarks>(typeof(Bookmarks).Name)).Returns(_mockCollection.Object);
		_mockService.Setup(g => g.UpdateAsync(It.IsAny<Bookmarks>())).Returns(Task.CompletedTask);

		var sut = new BookmarksController(_mockService.Object, _mockLogger.Object);
		Assert.NotNull(sut);

		var result = await sut.Update(_bookmarks);
		var okResult = result.Result as OkObjectResult;
		Assert.IsType<OkObjectResult>(okResult);

		_mockService.Verify(g => g.UpdateAsync(It.IsAny<Bookmarks>()), Times.Once());
	}

	[Fact]
	public async Task UpdateBookmarks_InValidModel_Failure()
	{
		_mockDbContext.Setup(c => c.GetCollection<Bookmarks>(typeof(Bookmarks).Name)).Returns(_mockCollection.Object);
		var bookmarks = new Bookmarks();

		var sut = new BookmarksController(_mockService.Object, _mockLogger.Object);
		Assert.NotNull(sut);
		sut.ModelState.AddModelError("userid", "userid is required");

		var result = await sut.Update(bookmarks);
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

		_mockDbContext.Setup(c => c.GetCollection<Bookmarks>(typeof(Bookmarks).Name)).Returns(_mockCollection.Object);
		_mockService.Setup(g => g.UpdateAsync(It.IsAny<Bookmarks>())).ThrowsAsync(new Exception());

		var sut = new BookmarksController(_mockService.Object, _mockLogger.Object);
		Assert.NotNull(sut);
		
		var result = await sut.Update(_bookmarks);
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

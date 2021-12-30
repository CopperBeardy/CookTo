using Microsoft.AspNetCore.Mvc;

namespace CookTo.Tests.ServerControllerTests.BookmarkControllerTests;

public class Create : BookmarksFixture
{

		 [Fact]
		 public async Task InsertBookmarks_ValidModel_Success()
		{
			_mockDbContext.Setup(c => c.GetCollection<Bookmarks>(typeof(Bookmarks).Name)).Returns(_mockCollection.Object);
			_mockService.Setup(g => g.CreateAsync(It.IsAny<Bookmarks>())).Returns(Task.CompletedTask);

			var sut = new BookmarksController(_mockService.Object, _mockLogger.Object);
			Assert.NotNull(sut);

			var result = await sut.Create(_bookmarks);
			var okResult = result.Result as OkObjectResult;
			Assert.IsType<OkObjectResult>(okResult);

		_mockService.Verify(g => g.CreateAsync(It.IsAny<Bookmarks>()), Times.Once());
	}

	[Fact]
	public async Task InsertBookmarks_InValidModel_Failure()
	{
		_mockDbContext.Setup(c => c.GetCollection<Bookmarks>(typeof(Bookmarks).Name)).Returns(_mockCollection.Object);
		var ingredient = new Bookmarks();

		var sut = new BookmarksController(_mockService.Object, _mockLogger.Object);
		Assert.NotNull(sut);
		sut.ModelState.AddModelError("Name", "Name is required");

		var result = await sut.Create(ingredient);
		var badRequestResult = result.Result as BadRequestResult;
		Assert.IsType<BadRequestResult>(badRequestResult);

		_mockService.Verify(g => g.CreateAsync(It.IsAny<Bookmarks>()), Times.Never());
	}

	[Fact]
	public async Task InsertBookmarks_ExceptionThrown_Failure()
	{
		_mockDbContext.Setup(c => c.GetCollection<Bookmarks>(typeof(Bookmarks).Name)).Returns(_mockCollection.Object);
		_mockService.Setup(g => g.CreateAsync(It.IsAny<Bookmarks>())).ThrowsAsync(new Exception());

		var sut = new BookmarksController(_mockService.Object, _mockLogger.Object);
		Assert.NotNull(sut);

		var result = await sut.Create(_bookmarks);
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

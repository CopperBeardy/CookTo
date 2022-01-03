using Microsoft.AspNetCore.Mvc;

namespace CookTo.Tests.UnitTests.BookmarkControllerTests;

public class Create : BookmarksFixture
{
	[Fact]
	public async Task InsertBookmarks_ValidModel_Success()
	{
		_mockService.Setup(g => g.CreateAsync(It.IsAny<Bookmarks>())).Returns(Task.CompletedTask);

		Assert.NotNull(SUT);

		var result = await SUT.Create(_bookmarks);
		var okResult = result.Result as OkObjectResult;
		Assert.IsType<OkObjectResult>(okResult);

		_mockService.Verify(g => g.CreateAsync(It.IsAny<Bookmarks>()), Times.Once());
	}

	[Fact]
	public async Task InsertBookmarks_InValidModel_Failure()
	{
		Assert.NotNull(SUT);
		SUT.ModelState.AddModelError("Name", "Name is required");

		var result = await SUT.Create(new Bookmarks());
		var badRequestResult = result.Result as BadRequestResult;
		Assert.IsType<BadRequestResult>(badRequestResult);

		_mockService.Verify(g => g.CreateAsync(It.IsAny<Bookmarks>()), Times.Never());
	}

	[Fact]
	public async Task InsertBookmarks_ExceptionThrown_Failure()
	{
		_mockService.Setup(g => g.CreateAsync(It.IsAny<Bookmarks>())).ThrowsAsync(new Exception());

		Assert.NotNull(SUT);

		var result = await SUT.Create(_bookmarks);
		var notFoundResult = result.Result as NotFoundResult;
		Assert.IsType<NotFoundResult>(notFoundResult);

		_mockLogger.Verify(
			l => l.Log(
				It.Is<LogLevel>(l => l == LogLevel.Error),
				It.IsAny<EventId>(),
				It.Is<It.IsAnyType>((@object, @type) => @object.ToString().Contains("insert") && type.Name == "FormattedLogValues"),
				It.IsAny<Exception>(),
				It.IsAny<Func<It.IsAnyType, Exception, string>>()),
			Times.Once());
	}
}

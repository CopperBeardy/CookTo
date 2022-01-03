using Microsoft.AspNetCore.Mvc;

namespace CookTo.Tests.UnitTests.BookmarkControllerTests;

public class Read : BookmarksFixture
{
	[Fact]
	public async Task GetByID_Bookmarks_Success()
	{
		_mockService.Setup(g => g.GetByIdAsync(It.IsAny<string>())).ReturnsAsync(_bookmarks);

		Assert.NotNull(SUT);

		var result = await SUT.GetById("1111a1111b1111c1111d1111");
		var okResult = result.Result as OkObjectResult;
		Assert.NotNull(okResult);
		Assert.IsType<OkObjectResult>(okResult);

		var obj = okResult.Value as Bookmarks;
		Assert.Equal(_bookmarks.UserId, obj.UserId);

		_mockService.Verify(g => g.GetByIdAsync(It.IsAny<string>()), Times.Once());
	}

	[Fact]
	public async Task GetById_Bookmarks_ExceptionThrown_Failure()
	{
		_mockService.Setup(g => g.GetByIdAsync(It.IsAny<string>())).ThrowsAsync(new Exception());

		Assert.NotNull(SUT);

		var result = await SUT.GetById("1111a1111b1111c1111d1111");
		var notFoundResult = result.Result as NotFoundResult;
		Assert.IsType<NotFoundResult>(notFoundResult);

		_mockLogger.Verify(
			l => l.Log(
				It.Is<LogLevel>(l => l == LogLevel.Error),
				It.IsAny<EventId>(),
				It.Is<It.IsAnyType>(
					(@object, @type) => @object.ToString().Contains("get") && type.Name == "FormattedLogValues"),
				It.IsAny<Exception>(),
				It.IsAny<Func<It.IsAnyType, Exception, string>>()),
			Times.Once());
	}

	[Theory]
	[InlineData("")]
	[InlineData(null)]
	public async Task GetByID_Bookmarks_InvalidId_Success(string id)
	{
		Assert.NotNull(SUT);

		var result = await SUT.GetById(id);
		var badRequesstResult = result.Result as BadRequestResult;
		Assert.IsType<BadRequestResult>(badRequesstResult);

		_mockService.Verify(g => g.GetByIdAsync(It.IsAny<string>()), Times.Never());
	}
}

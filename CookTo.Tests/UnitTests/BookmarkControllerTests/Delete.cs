using Microsoft.AspNetCore.Mvc;

namespace CookTo.Tests.UnitTests.BookmarkControllerTests;

public class Delete : BookmarksFixture
{
	[Fact]
	public async Task Delete_Bookmarks_Success()
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
	public async Task Delete_Bookmarks_ExceptionThrown_Failure()
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
	public async Task Delete_Bookmarks_InvalidId_Success(string id)
	{
		Assert.NotNull(SUT);

		var result = await SUT.Delete(id);
		var badRequestResult = result.Result as BadRequestResult;
		Assert.IsType<BadRequestResult>(badRequestResult);

		_mockService.Verify(g => g.GetByIdAsync(It.IsAny<string>()), Times.Never());
	}
}

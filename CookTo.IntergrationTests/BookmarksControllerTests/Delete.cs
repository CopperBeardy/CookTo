using System;
using System.Linq;

namespace CookTo.Tests.Intergration.BookmarksControllerTests;

public class Delete : BookmarksFixture
{
	[Fact]

	public async Task Delete_ValidId_OkResult_Success()
	{
		var read = await SUT.GetAll();
		var objResult = Assert.IsAssignableFrom<OkObjectResult>(read.Result);
		var listResult = Assert.IsAssignableFrom<List<Bookmarks>>(objResult.Value);

		var result = await SUT.Delete(listResult.First().Id.ToString());
		Assert.NotNull(result);

		var obj = Assert.IsAssignableFrom<OkObjectResult>(result.Result);

		var value = Assert.IsAssignableFrom<bool>(obj.Value);
		Assert.True(value);
	}

	[Fact]
	public async Task Delete_InValidId_NotFoundResult_Failure()
	{
		var result = await SUT.Delete(Guid.NewGuid().ToString());
		Assert.NotNull(result);

		var obj = Assert.IsAssignableFrom<NotFoundResult>(result.Result);

		Assert.IsAssignableFrom<NotFoundResult>(obj);
	}
}

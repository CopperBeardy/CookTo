using System;
using System.Linq;

namespace CookTo.Tests.Intergration.BookmarksControllerTests;

public class Update : BookmarksFixture
{
	[Fact]
	public async Task Update_ValidObject_OkResult_Success()
	{
		var read = await SUT.GetAll();
		var objResult = Assert.IsAssignableFrom<OkObjectResult>(read.Result);
		var listResult = Assert.IsAssignableFrom<List<Bookmarks>>(objResult.Value);
		var item = listResult.First();
		var updateValue = "White bread flour";
		item.BookmarkedRecipes.First().Title = updateValue;

		var result = await SUT.Update(item);
		Assert.NotNull(result);

		Assert.IsAssignableFrom<OkObjectResult>(result.Result);

		var readUpdate = await SUT.GetAll();
		var objUpdateResult = Assert.IsAssignableFrom<OkObjectResult>(readUpdate.Result);
		var listUpdateResult = Assert.IsAssignableFrom<List<Bookmarks>>(objUpdateResult.Value);
		var itemUpdated = listUpdateResult.First();
		Assert.Equal(updateValue, itemUpdated.BookmarkedRecipes.First().Title);

	}

	[Theory]
	[InlineData(null)]
	[InlineData("")]

	public async Task Update_InValidObject_BadRequest_Failure(string? value)
	{
		var read = await SUT.GetAll();
		var objResult = Assert.IsAssignableFrom<OkObjectResult>(read.Result);
		var listResult = Assert.IsAssignableFrom<List<Bookmarks>>(objResult.Value);
		var item = listResult.First();
		item.UserId = value;

		var result = await SUT.Update(item);
		Assert.NotNull(result);

		Assert.IsAssignableFrom<BadRequestResult>(result.Result);
	}


}

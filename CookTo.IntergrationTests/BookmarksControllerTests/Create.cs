using MongoDB.Bson;
using System;
using System.Linq;

namespace CookTo.Tests.Intergration.BookmarksControllerTests;

public class Create : BookmarksFixture
{
	[Fact]
	public async Task Create_Recipe_OkResult_Success()
	{
		var Bookmarks = new Bookmarks
		{
			UserId = Guid.NewGuid().ToString(),
			BookmarkedRecipes = new List<Bookmarked>()
			  {
				  new Bookmarked()
				  {
					 RecipeId = ObjectId.GenerateNewId(),
					 Title = "White bread loaf"
				  },
				  new Bookmarked()
				  {
					 RecipeId = ObjectId.GenerateNewId(),
					 Title = "Sponge cake"
				  }
			  }
		};
		var result = await SUT.Create(Bookmarks);

		Assert.NotNull(result);

		var obj = Assert.IsAssignableFrom<OkObjectResult>(result.Result);
		var value = Assert.IsType<bool>(obj.Value);
		Assert.True(value);

	}

	[Fact]
	public async Task Create_Bookmarks_RequiredValueMissing_BadRequestResult_Failure()
	{
		var Bookmarks = new Bookmarks();

		var result = await SUT.Create(Bookmarks);

		Assert.NotNull(result);
		Assert.IsAssignableFrom<BadRequestResult>(result.Result);
	}

}

using System;
using System.Linq;

namespace CookTo.Tests.Intergration.BookmarksControllerTests;

public class Read : BookmarksFixture
{
	[Fact]
	public async Task GetAll_Bookmarks_OkResult_Success()
	{
		var expected = list[0].BookmarkedRecipes.First().Title;
		var result = await SUT.GetAll();

		Assert.NotNull(result);

		var obj = Assert.IsAssignableFrom<OkObjectResult>(result.Result);

		var listResult = Assert.IsAssignableFrom<List<Bookmarks>>(obj.Value);

		Assert.Equal(2, list.Count);
		var firstItem = listResult.First();


		Assert.Equal(expected, firstItem.BookmarkedRecipes.First().Title);

	}

	[Fact]
	public async Task GetAll_CollectionNotExisting_OkResult_EmptyList_Success()
	{
		MongoClient client = new MongoClient(connectionString);
		var database = client.GetDatabase(db);
		database.DropCollection(collection);

		var result = await SUT.GetAll();
		//assert
		Assert.NotNull(result);

		var obj = Assert.IsAssignableFrom<OkObjectResult>(result.Result);

		var list = Assert.IsAssignableFrom<List<Bookmarks>>(obj.Value);
		Assert.Empty(list);
	}

	[Fact]
	public async Task GetByUserId_ValidId_OkResult_Success()
	{
		var id = list[0].UserId.ToString();
		var result = await SUT.GetByUserId(id);
		//assert
		Assert.NotNull(result);
		Assert.NotNull(result.Result);
		var obj = Assert.IsAssignableFrom<OkObjectResult>(result.Result);

		var singleResult = Assert.IsAssignableFrom<Bookmarks>(obj.Value);
		Assert.Equal(id, singleResult.UserId);
	}

	[Fact]
	public async Task GetByUserId_UserIdNotPresent_OkResult_Success()
	{
		MongoClient client = new MongoClient(connectionString);
		var database = client.GetDatabase(db);
		database.DropCollection(collection);

		var result = await SUT.GetByUserId("aaaa1aaaa1aaaa1aaaa1aaaa");
		//assert
		Assert.NotNull(result);

		var obj = Assert.IsAssignableFrom<OkObjectResult>(result.Result);
		Assert.Null(obj.Value);
	}
}

using MongoDB.Bson;
using System;
using System.Linq;

namespace CookTo.Tests.Intergration.BookmarksControllerTests;

public class BookmarksControllerTests
{
	[Fact]
	public async Task Create_Bookmarks_ValidModel_OkResult()
	{
		var fixture = new BookmarksFixture();
		fixture.SetupCollection();
		var Bookmarks = new Bookmarks
		{
			UserId = Guid.NewGuid().ToString(),
			BookmarkedRecipes =
				new List<Bookmarked>()
				{
					new Bookmarked() { RecipeId = ObjectId.GenerateNewId(), Title = "White bread loaf" },
					new Bookmarked() { RecipeId = ObjectId.GenerateNewId(), Title = "Sponge cake" }
				}
		};
		var result = await fixture.SUT.CreateAsync(Bookmarks);

		Assert.NotNull(result);

		var obj = Assert.IsAssignableFrom<OkObjectResult>(result.Result);
		Assert.IsType<Bookmarks>(obj.Value);
		fixture.Dispose();
	}

	[Fact]
	public async Task Create_Bookmarks_RequiredValueMissing_BadRequestResult()
	{
		var fixture = new BookmarksFixture();

		var result = await fixture.SUT.CreateAsync(new Bookmarks());

		Assert.NotNull(result);
		Assert.IsAssignableFrom<BadRequestResult>(result.Result);
		fixture.Dispose();
	}

	[Fact]
	public async Task GetAll_Bookmarks_OkResult()
	{
		var fixture = new BookmarksFixture();
		fixture.SetupCollection();
		var expected = fixture.list;
		var expectedTitle = expected[0].BookmarkedRecipes.First().Title;
		var result = await fixture.SUT.GetAllAsync();

		Assert.NotNull(result);

		var obj = Assert.IsAssignableFrom<OkObjectResult>(result.Result);

		var listResult = Assert.IsAssignableFrom<List<Bookmarks>>(obj.Value);

		Assert.Equal(2, expected.Count);
		var firstItem = listResult.First();

		Assert.Equal(expectedTitle, firstItem.BookmarkedRecipes.First().Title);
		fixture.Dispose();
	}

	[Fact]
	public async Task GetAll_Bookmarks_CollectionNotExisting_OkResult()
	{
		var fixture = new BookmarksFixture();

		var result = await fixture.SUT.GetAllAsync();
		//assert
		Assert.NotNull(result);

		var obj = Assert.IsAssignableFrom<OkObjectResult>(result.Result);

		var list = Assert.IsAssignableFrom<List<Bookmarks>>(obj.Value);
		Assert.Empty(list);
		fixture.Dispose();
	}

	[Fact]
	public async Task GetByUserId_Boomarks_ValidId_OkResult()
	{
		var fixture = new BookmarksFixture();
		fixture.SetupCollection();
		var expected = fixture.list;
		var id = expected.First().UserId.ToString();
		var result = await fixture.SUT.GetByUserIdAsync(id);
		//assert
		Assert.NotNull(result);
		Assert.NotNull(result.Result);
		var obj = Assert.IsAssignableFrom<OkObjectResult>(result.Result);

		var singleResult = Assert.IsAssignableFrom<Bookmarks>(obj.Value);
		Assert.Equal(id, singleResult.UserId);
		fixture.Dispose();
	}

	[Fact]
	public async Task GetByUserId_Bookmarks_UserIdNotPresent_OkResult()
	{
		var fixture = new BookmarksFixture();
		fixture.SetupCollection();

		var result = await fixture.SUT.GetByUserIdAsync(Guid.NewGuid().ToString());
		//assert
		Assert.NotNull(result);

		var obj = Assert.IsAssignableFrom<OkObjectResult>(result.Result);
		Assert.Null(obj.Value);
		fixture.Dispose();
	}

	[Fact]

	public async Task Delete_Bookmarks_ValidId_OkResult()
	{
		var fixture = new BookmarksFixture();
		fixture.SetupCollection();
		var read = await fixture.SUT.GetAllAsync();
		var objResult = Assert.IsAssignableFrom<OkObjectResult>(read.Result);
		var listResult = Assert.IsAssignableFrom<List<Bookmarks>>(objResult.Value);

		var result = await fixture.SUT.DeleteAsync(listResult.First().Id.ToString());
		Assert.NotNull(result);

		var obj = Assert.IsAssignableFrom<OkObjectResult>(result.Result);

		var value = Assert.IsAssignableFrom<bool>(obj.Value);
		Assert.True(value);
		fixture.Dispose();
	}

	[Fact]
	public async Task Delete_Bookmarks_InValidId_NotFoundResult()
	{
		var fixture = new BookmarksFixture();
		fixture.SetupCollection();
		var result = await fixture.SUT.DeleteAsync(Guid.NewGuid().ToString());
		Assert.NotNull(result);

		var obj = Assert.IsAssignableFrom<NotFoundResult>(result.Result);

		Assert.IsAssignableFrom<NotFoundResult>(obj);
		fixture.Dispose();
	}

	[Fact]
	public async Task Update_Bookmarks_ValidObject_OkResult()
	{
		var fixture = new BookmarksFixture();
		fixture.SetupCollection();
		var items = fixture.list;
		var item = items.First();
		var updateValue = "White bread flour";
		item.BookmarkedRecipes.First().Title = updateValue;

		var result = await fixture.SUT.UpdateAsync(item);
		Assert.NotNull(result);

		Assert.IsAssignableFrom<OkObjectResult>(result.Result);

		var readUpdate = await fixture.SUT.GetAllAsync();
		var objUpdateResult = Assert.IsAssignableFrom<OkObjectResult>(readUpdate.Result);
		var listUpdateResult = Assert.IsAssignableFrom<List<Bookmarks>>(objUpdateResult.Value);
		var itemUpdated = listUpdateResult.First();
		Assert.Equal(updateValue, itemUpdated.BookmarkedRecipes.First().Title);
		fixture.Dispose();
	}

	[Theory]
	[InlineData(null)]
	[InlineData("")]
	public async Task Update_Bookmarks_InValidObject_BadRequest(string? value)
	{
		var fixture = new BookmarksFixture();
		fixture.SetupCollection();
		var read = await fixture.SUT.GetAllAsync();
		var objResult = Assert.IsAssignableFrom<OkObjectResult>(read.Result);
		var listResult = Assert.IsAssignableFrom<List<Bookmarks>>(objResult.Value);
		var item = listResult.First();
		item.UserId = value;

		var result = await fixture.SUT.UpdateAsync(item);
		Assert.NotNull(result);

		Assert.IsAssignableFrom<BadRequestResult>(result.Result);
		fixture.Dispose();
	}
}

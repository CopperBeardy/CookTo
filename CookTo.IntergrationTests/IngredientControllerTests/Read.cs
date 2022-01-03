

namespace CookTo.Tests.Intergration.IngredientControllerTests;

public class Read: IngredientFixture
{

	[Fact]
	public async Task GetAll_Ingredients_OkResult_Success()
	{ 
		var result = await SUT.GetAll();

		Assert.NotNull(result);

		var obj = Assert.IsAssignableFrom<OkObjectResult>(result.Result);

		var listResult = Assert.IsAssignableFrom<List<Ingredient>>(obj.Value);

		Assert.Equal(2,list.Count);
		var firstItem = listResult.First();
		Assert.Equal(list[0].Name, firstItem.Name);

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

		var list =Assert.IsAssignableFrom<List<Ingredient>>(obj.Value);
		Assert.Empty(list);
	}

	[Fact]
	public async Task GetById_ValidId_OkResult_Success()
	{
		var id = list[0].Id.ToString();
		var result = await SUT.GetById(id);
		//assert
		Assert.NotNull(result);
		 Assert.NotNull(result.Result);
		var obj = Assert.IsAssignableFrom<OkObjectResult>(result.Result);	

		var singleResult = 	Assert.IsAssignableFrom<Ingredient>	(obj.Value );
		Assert.Equal(id, singleResult.Id.ToString());
	}

	[Fact]
	public async Task GetById_IngredientNotExisting_OkResult_Success()
	{
		MongoClient client = new MongoClient(connectionString);
		var database = client.GetDatabase(db);
		database.DropCollection(collection);

		var result = await SUT.GetById("aaaa1aaaa1aaaa1aaaa1aaaa");
		//assert
		Assert.NotNull(result);

		var obj = Assert.IsAssignableFrom<OkObjectResult>(result.Result);
	   Assert.Null(obj.Value);
	}

	[Theory]
	[InlineData(null)]
	[InlineData("")]
	public async Task GetById_InvalidId_BadResult_Failure(string id)
	{
		MongoClient client = new MongoClient(connectionString);
		var database = client.GetDatabase(db);
		database.DropCollection(collection);

		var result = await SUT.GetById(id);
		//assert
		Assert.NotNull(result);

		Assert.IsAssignableFrom<BadRequestResult>(result.Result);

	}
}

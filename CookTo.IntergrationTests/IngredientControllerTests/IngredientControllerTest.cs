using MongoDB.Bson;

namespace CookTo.Tests.Intergration.IngredientControllerTests;

public class IngredientControllerTest
{
	[Fact]
	public async Task Create_Ingredient_OkResult_Success()
	{
		var fixture = new IngredientFixture();
		fixture.SetupCollection();
		var ingredient = new Ingredient
		{
			Name = "Flour"
		};
		var result = await fixture.SUT.Create(ingredient);

		Assert.NotNull(result);

		var obj = Assert.IsAssignableFrom<OkObjectResult>(result.Result);
		var value = Assert.IsType<bool>(obj.Value);
		Assert.True(value);
		fixture.Dispose();
	}

	[Fact]
	public async Task Create_Ingredient_RequiredValueMissing_BadRequestResult_Failure()
	{
		var fixture = new IngredientFixture();
		fixture.SetupCollection();
		var ingredient = new Ingredient();

		var result = await fixture.SUT.Create(ingredient);

		Assert.NotNull(result);
		Assert.IsAssignableFrom<BadRequestResult>(result.Result);
		fixture.Dispose();
	}

	[Fact]
	public async Task Create_Ingredient_LessThanMinLengthValue_BadRequestResult_Failure()
	{
		var fixture = new IngredientFixture();
		fixture.SetupCollection();
		var ingredient = new Ingredient()
		{
			Name = "a"
		};

		var result = await fixture.SUT.Create(ingredient);

		Assert.NotNull(result);
		Assert.IsAssignableFrom<BadRequestResult>(result.Result);
		fixture.Dispose();
	}
	[Fact]
	public async Task Delete_ValidId_OkResult_Success()
	{
		var fixture = new IngredientFixture();
		fixture.SetupCollection();
		var items = fixture.list;	 

		var result = await fixture.SUT.Delete(items.First().Id.ToString());
		Assert.NotNull(result);

		var obj = Assert.IsAssignableFrom<OkObjectResult>(result.Result);

		var value = Assert.IsAssignableFrom<bool>(obj.Value);
		Assert.True(value);
		fixture.Dispose();
	}

	[Fact]
	public async Task Delete_InValidId_NotFoundResult_Failure()
	{
		var fixture = new IngredientFixture();
		fixture.SetupCollection();
		var result = await fixture.SUT.Delete(Guid.NewGuid().ToString());
		Assert.NotNull(result);

		var obj = Assert.IsAssignableFrom<NotFoundResult>(result.Result);

		Assert.IsAssignableFrom<NotFoundResult>(obj);
		fixture.Dispose();
	}


	[Fact]
	public async Task GetAll_Ingredients_OkResult_Success()
	{
		var fixture = new IngredientFixture();
		fixture.SetupCollection();
		var expected = fixture.list;

		var result = await fixture.SUT.GetAll();

		Assert.NotNull(result);

		var obj = Assert.IsAssignableFrom<OkObjectResult>(result.Result);

		var listResult = Assert.IsAssignableFrom<List<Ingredient>>(obj.Value);

		Assert.Equal(2, expected.Count);
		var firstItem = listResult.First();
		Assert.Equal(expected.First().Name, firstItem.Name);

		fixture.Dispose();
	}

	[Fact]
	public async Task GetAll_CollectionNotExisting_OkResult_EmptyList_Success()
	{
		var fixture = new IngredientFixture();

		var result = await fixture.SUT.GetAll();
		//assert
		Assert.NotNull(result);

		var obj = Assert.IsAssignableFrom<OkObjectResult>(result.Result);

		var list = Assert.IsAssignableFrom<List<Ingredient>>(obj.Value);
		Assert.Empty(list);
		fixture.Dispose();
	}

	[Fact]
	public async Task GetById_ValidId_OkResult_Success()
	{
		var fixture = new IngredientFixture();
		fixture.SetupCollection();
		var expected = fixture.list;
		var id = expected[0].Id.ToString();

		var result = await fixture.SUT.GetById(id);
		//assert
		Assert.NotNull(result);
		Assert.NotNull(result.Result);
		var obj = Assert.IsAssignableFrom<OkObjectResult>(result.Result);

		var singleResult = Assert.IsAssignableFrom<Ingredient>(obj.Value);
		Assert.Equal(id, singleResult.Id.ToString());
		fixture.Dispose();
	}

	[Fact]
	public async Task GetById_IngredientNotExisting_OkResult_Success()
	{
		var fixture = new IngredientFixture();

		var result = await fixture.SUT.GetById(ObjectId.GenerateNewId().ToString());
		//assert
		Assert.NotNull(result);

		var obj = Assert.IsAssignableFrom<OkObjectResult>(result.Result);
		Assert.Null(obj.Value);
		fixture.Dispose();
	}

	[Theory]
	[InlineData(null)]
	[InlineData("")]
	public async Task GetById_InvalidId_BadResult_Failure(string id)
	{
		var fixture = new IngredientFixture();

		var result = await fixture.SUT.GetById(id);
		//assert
		Assert.NotNull(result);

		Assert.IsAssignableFrom<BadRequestResult>(result.Result);
		fixture.Dispose();
	}

	[Theory]
	[InlineData("Bread")]
	[InlineData("Milk")]
	public async Task GetByName_ValidName_OKResult_Success(string name)
	{
		var fixture = new IngredientFixture();
		fixture.SetupCollection();

		var result = await fixture.SUT.GetByName(name);

		Assert.NotNull(result);
		var obj = Assert.IsAssignableFrom<OkObjectResult>(result.Result);

		var value = Assert.IsAssignableFrom<Ingredient>(obj.Value);
		Assert.NotNull(value);
		Assert.Equal(name, value.Name);
		fixture.Dispose();
	}

	[Theory]
	[InlineData(null)]
	[InlineData("")]
	public async Task GetByName_InvalidName_BadResult_Failure(string name)
	{
		var fixture = new IngredientFixture();

		var result = await fixture.SUT.GetByName(name);
		//assert
		Assert.NotNull(result);

		Assert.IsAssignableFrom<BadRequestResult>(result.Result);

		fixture.Dispose();
	}

	[Fact]
	public async Task Update_ValidObject_OkResult_Success()
	{
		var fixture = new IngredientFixture();
		fixture.SetupCollection(); 		
		var item = fixture.list.First();
		var expected = "White bread flour";
		item.Name = expected;

		var result = await fixture.SUT.Update(item);
		Assert.NotNull(result);

		Assert.IsAssignableFrom<OkObjectResult>(result.Result);

		var readUpdate = await fixture.SUT.GetAll();
		var objUpdateResult = Assert.IsAssignableFrom<OkObjectResult>(readUpdate.Result);
		var listUpdateResult = Assert.IsAssignableFrom<List<Ingredient>>(objUpdateResult.Value);
		var itemUpdated = listUpdateResult.First();
		Assert.Equal(expected, itemUpdated.Name);
		fixture.Dispose();

	}

	[Theory]
	[InlineData(null)]
	[InlineData("")]
	public async Task Update_InValidObject_BadRequest_Failure(string? value)
	{
		var fixture = new IngredientFixture();
		fixture.SetupCollection();
		var items = fixture.list; 	
		var item = items.First();
		item.Name = value;

		var result = await fixture.SUT.Update(item);
		Assert.NotNull(result);

		Assert.IsAssignableFrom<BadRequestResult>(result.Result);
		fixture.Dispose();
	}



}

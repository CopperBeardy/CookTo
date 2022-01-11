using MongoDB.Bson;

namespace CookTo.Tests.Intergration.IngredientControllerTests;

public class IngredientControllerTest
{
	[Fact]
	public async Task Create_Ingredient_OkResult()
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
		Assert.IsType<Ingredient>(obj.Value);
		
		fixture.Dispose();
	}

	[Fact]
	public async Task Create_Ingredient_InvalidModelMissingValue_BadRequestResult()
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
	public async Task Create_Ingredient_InvalidModel_BadRequestResult()
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
	public async Task Delete_Ingredient_ValidId_OkResult()
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
	public async Task Delete_Ingredient_InValidId_NotFoundResult()
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
	public async Task GetAll_Ingredients_OkResult()
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
	public async Task GetAll_Ingredient_CollectionNotExisting_OkResult()
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
	public async Task GetById_Ingredient_ValidId_OkResult()
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
	public async Task GetById_Ingredient_NotExisting_OkResult()
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
	public async Task GetById_Ingredient_InvalidId_BadResult(string id)
	{
		var fixture = new IngredientFixture();

		var result = await fixture.SUT.GetById(id);
		//assert
		Assert.NotNull(result);

		Assert.IsAssignableFrom<BadRequestResult>(result.Result);
		fixture.Dispose();
	}

	[Fact]
	public async Task Update_Ingredient_ValidObject_OkResult()
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
	public async Task Update_Ingredient_InValidObject_BadRequest(string? value)
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

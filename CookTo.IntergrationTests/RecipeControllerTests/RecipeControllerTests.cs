using MongoDB.Bson;

namespace CookTo.Tests.Intergration.RecipeControllerTests;

public class RecipeControllerTests	
{

	[Fact]
	public async Task Create_Recipe_OkResult_Success()
	{
		var fixture = new RecipeFixture();
		fixture.SetupCollection();
		var recipe = new Recipe()
		{
			Title = "Steak Gravy Pie",
			Category = "Baking",
			Description = "steak Pie with puff pastry and vegtables",
			ImageUrl = "test3.png",
			PrepartionTime = 60,
			CookingTime = 240,
			Serves = 4,
			AuthorId = Guid.NewGuid().ToString(),
			RecipeParts = new List<RecipePart>()
				 {
					 new RecipePart()
					 {
						 Title = "filling for pie",
						 Items = new List<string>()
						 {
							 "300g braising steak"
					}
				}
			},
			CookingSteps = new List<CookingStep>
			{
				new CookingStep()  { StepOrder = 1,Step = "mix butter and sugar until fluffy" }
			},
			Tips = new List<string>
			{
				"ensure cakes are firm before removin from oven"
			}
		};
		var result = await fixture.SUT.Create(recipe);

		Assert.NotNull(result);

		var obj = Assert.IsAssignableFrom<OkObjectResult>(result.Result);
		var value = Assert.IsType<bool>(obj.Value);
		Assert.True(value);
		fixture.Dispose();
	}

	[Fact]
	public async Task Create_Recipe_RequiredValueMissing_BadRequestResult_Failure()
	{
		var fixture = new RecipeFixture();
		var recipe = new Recipe();

		var result = await fixture.SUT.Create(recipe);

		Assert.NotNull(result);
		Assert.IsAssignableFrom<BadRequestResult>(result.Result);
		fixture.Dispose();
	}

	[Fact]
	public async Task Create_Recipe_LessThanMinLengthValue_BadRequestResult_Failure()
	{
		var fixture = new RecipeFixture();	 		
		var recipe = new Recipe()
		{
			Title = "a"
		};

		var result = await fixture.SUT.Create(recipe);

		Assert.NotNull(result);
		Assert.IsAssignableFrom<BadRequestResult>(result.Result);
		fixture.Dispose();
	}
	[Fact]
	public async Task GetAll_Recipes_OkResult_Success()
	{
		var fixture = new RecipeFixture();
		fixture.SetupCollection();
		var expected = fixture.list;
		var result = await fixture.SUT.GetAll();

		Assert.NotNull(result);

		var obj = Assert.IsAssignableFrom<OkObjectResult>(result.Result);

		var listResult = Assert.IsAssignableFrom<List<Recipe>>(obj.Value);

		Assert.Equal(2, expected.Count);
		var firstItem = listResult.First();
		Assert.Equal(expected[0].Title, firstItem.Title);
		fixture.Dispose();
	}

	[Fact]
	public async Task GetAll_CollectionNotExisting_OkResult_EmptyList_Success()
	{
		var fixture = new RecipeFixture();

		var result = await fixture.SUT.GetAll();
		//assert
		Assert.NotNull(result);

		var obj = Assert.IsAssignableFrom<OkObjectResult>(result.Result);

		var list = Assert.IsAssignableFrom<List<Recipe>>(obj.Value);
		Assert.Empty(list);
		fixture.Dispose();
	}

	[Fact]
	public async Task GetById_ValidId_OkResult_Success()
	{
		var fixture = new RecipeFixture();
		fixture.SetupCollection();
		var id = fixture.list.First().Id.ToString();
		var result = await fixture.SUT.GetById(id);
		//assert
		Assert.NotNull(result);
		Assert.NotNull(result.Result);
		var obj = Assert.IsAssignableFrom<OkObjectResult>(result.Result);

		var singleResult = Assert.IsAssignableFrom<Recipe>(obj.Value);
		Assert.Equal(id, singleResult.Id.ToString());
		fixture.Dispose();
	}

	[Fact]
	public async Task GetById_RecipeNotExisting_OkResult_Success()
	{
		var fixture = new RecipeFixture();
		fixture.SetupCollection();

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
		var fixture = new RecipeFixture();

		var result = await fixture.SUT.GetById(id);
		//assert
		Assert.NotNull(result);

		Assert.IsAssignableFrom<BadRequestResult>(result.Result);
		fixture.Dispose();
	}
	[Fact]

	public async Task Delete_ValidId_OkResult_Success()
	{
		var fixture = new RecipeFixture();
		fixture.SetupCollection();
		var id = fixture.list.First().Id.ToString();
		var result = await fixture.SUT.Delete(id);
		Assert.NotNull(result);

		var obj = Assert.IsAssignableFrom<OkObjectResult>(result.Result);

		var value = Assert.IsAssignableFrom<bool>(obj.Value);
		Assert.True(value);
		fixture.Dispose();
	}

	[Fact]
	public async Task Delete_InValidId_NotFoundResult_Failure()
	{
		var fixture = new RecipeFixture();

		var result = await fixture.SUT.Delete(Guid.NewGuid().ToString());
		Assert.NotNull(result);

		var obj = Assert.IsAssignableFrom<NotFoundResult>(result.Result);

		Assert.IsAssignableFrom<NotFoundResult>(obj);
		fixture.Dispose();
	}

	[Fact]
	public async Task Update_ValidObject_OkResult_Success()
	{
		var fixture = new RecipeFixture();
		fixture.SetupCollection();
	
		var item = fixture.list.First();
		var updateValue = "White bread flour";
		item.Title = updateValue;

		var result = await fixture.SUT.Update(item);
		Assert.NotNull(result);

		Assert.IsAssignableFrom<OkObjectResult>(result.Result);

		var readUpdate = await fixture.SUT.GetAll();
		var objUpdateResult = Assert.IsAssignableFrom<OkObjectResult>(readUpdate.Result);
		var listUpdateResult = Assert.IsAssignableFrom<List<Recipe>>(objUpdateResult.Value);
		var itemUpdated = listUpdateResult.First();
		Assert.Equal(updateValue, itemUpdated.Title);
		fixture.Dispose();
	}

	[Theory]
	[InlineData(null)]
	[InlineData("")]
	public async Task Update_InValidObject_BadRequest_Failure(string? value)
	{
		var fixture = new RecipeFixture();
		fixture.SetupCollection();	

		var item = fixture.list.First();
		item.Title = value;

		var result = await fixture.SUT.Update(item);
		Assert.NotNull(result);

		Assert.IsAssignableFrom<BadRequestResult>(result.Result);
		fixture.Dispose();
	}



}

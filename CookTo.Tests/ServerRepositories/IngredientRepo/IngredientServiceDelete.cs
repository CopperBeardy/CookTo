using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CookTo.Server.DbContext;
using CookTo.Server.Repositories;
using CookTo.Shared.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using Moq;
using Xunit;

namespace CookTo.Tests.ServerRepositories.IngredientRepo;

public class IngredientServiceDelete
{
	private Mock<IMongoCollection<Ingredient>> _mockCollection;
	private Mock<ICookToDbContext> _mockContext;
	private Ingredient _ingredient;
	private List<Ingredient> _list;

	public IngredientServiceDelete()
	{
		string id = "1234a1234b1234c1234d1234";
		var oid = new ObjectId(id);

		_ingredient = new Ingredient()
		{
			Id = oid,
			Name = "Cheese"
		};
		_mockCollection = new Mock<IMongoCollection<Ingredient>>();
		_mockCollection.Object.InsertOne(_ingredient);
		_mockContext = new Mock<ICookToDbContext>();
		_list = new List<Ingredient>();
		_list.Add(_ingredient);

	}

	[Fact]
	public async Task IngredientService_RemoveItem_Succuess()
	{ 
		_mockCollection.Setup(x => x.DeleteOneAsync(
			It.IsAny<FilterDefinition<Ingredient>>(),
			It.IsAny<CancellationToken>()))
			.ReturnsAsync(new DeleteResult.Acknowledged(1)).Verifiable();
		
		//Mock GetCollection
		_mockContext.Setup(c => c.GetCollection<Ingredient>(typeof(Ingredient).Name))
		.Returns(_mockCollection.Object);
		var ingredientRepo = new IngredientRepository(_mockContext.Object);

		//Delete item
		var result = await ingredientRepo.DeleteAsync("1234a1234b1234c1234d1234");
		  Assert.Equal(result.DeletedCount, 1);
		//verify the DeleteOneAsync is called once
		_mockCollection.Verify(c => c.DeleteOneAsync(It.IsAny<FilterDefinition<Ingredient>>(),
			It.IsAny<CancellationToken>()), Times.Once);

	}
}

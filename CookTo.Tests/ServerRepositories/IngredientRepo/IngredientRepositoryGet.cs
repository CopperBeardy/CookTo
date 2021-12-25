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

public class IngredientRepositoryGet
{
	private Mock<IMongoCollection<Ingredient>> _mockCollection;
	private Mock<ICookToDbContext> _mockContext;
	private Ingredient _ingredient;
	private List<Ingredient> _list;
	
	public IngredientRepositoryGet()
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
	public async Task IngredientService_GetIngrediedntById_valid_Success()
	{
		//Mock MoveNextAsync
		Mock<IAsyncCursor<Ingredient>> _ingredientCursor = new Mock<IAsyncCursor<Ingredient>>();
		_ingredientCursor.Setup(_ => _.Current).Returns(_list);
		_ingredientCursor.SetupSequence(_ => _.MoveNext(It.IsAny<CancellationToken>()))
			.Returns(true)
			.Returns(false);
		_ingredientCursor.SetupSequence(_ => _.MoveNextAsync(It.IsAny<CancellationToken>()))
			.Returns(Task.FromResult(true))
			.Returns(Task.FromResult(false));
		//Mock FindAsync
		_mockCollection.Setup(op => op.FindAsync(It.IsAny<FilterDefinition<Ingredient>>(),
			It.IsAny<FindOptions<Ingredient, Ingredient>>(),
			It.IsAny<CancellationToken>()))
			.ReturnsAsync(_ingredientCursor.Object);

		//Mock GetCollection
		_mockContext.Setup(c => c.GetCollection<Ingredient>(typeof(Ingredient).Name)).Returns(_mockCollection.Object);
		var ingredientRepo = new IngredientRepository(_mockContext.Object);

		var result = await ingredientRepo.GetByIdAsync("1234a1234b1234c1234d1234");

		Assert.NotNull(result);
		Assert.Equal(result.Id, _list.First().Id);

		//verify the InsertOneAsync is called once
		_mockCollection.Verify(c => c.FindAsync(It.IsAny<FilterDefinition<Ingredient>>(),
			It.IsAny<FindOptions<Ingredient>>(),
			It.IsAny<CancellationToken>()), Times.Once);
	}

	[Fact]
	public async Task IngredientService_GetIngrediedntById_ThrowException_Failure()
	{
		//Mock MoveNextAsync
		Mock<IAsyncCursor<Ingredient>> _ingredientCursor = new Mock<IAsyncCursor<Ingredient>>();
		_ingredientCursor.Setup(_ => _.Current).Returns(_list);
		_ingredientCursor.SetupSequence(_ => _.MoveNext(It.IsAny<CancellationToken>()))
			.Returns(true)
			.Returns(false);
		_ingredientCursor.SetupSequence(_ => _.MoveNextAsync(It.IsAny<CancellationToken>()))
			.Returns(Task.FromResult(true))
			.Returns(Task.FromResult(false));
		//Mock FindAsync
		_mockCollection.Setup(op => op.FindAsync(It.IsAny<FilterDefinition<Ingredient>>(),
			It.IsAny<FindOptions<Ingredient, Ingredient>>(),
			It.IsAny<CancellationToken>()))
			.ThrowsAsync(new Exception());

		//Mock GetCollection
		_mockContext.Setup(c => c.GetCollection<Ingredient>(typeof(Ingredient).Name)).Returns(_mockCollection.Object);
		var ingredientRepo = new IngredientRepository(_mockContext.Object);

		var result = () =>  ingredientRepo.GetByIdAsync("1234a1234b1234c1234d1234");

		await Assert.ThrowsAsync<Exception>(result);

		//verify the InsertOneAsync is called once
		_mockCollection.Verify(c => c.FindAsync(It.IsAny<FilterDefinition<Ingredient>>(),
			It.IsAny<FindOptions<Ingredient>>(),
			It.IsAny<CancellationToken>()), Times.Once);
	}


	[Fact]
	public async Task IngredientService_GetAllIngredientAsync_Valid_Success()
	{
		//Mock MoveNextAsync
		Mock<IAsyncCursor<Ingredient>> _ingredientCursor = new Mock<IAsyncCursor<Ingredient>>();
		_ingredientCursor.Setup(_ => _.Current).Returns(_list);
		_ingredientCursor.SetupSequence(_ => _	.MoveNext(It.IsAny<CancellationToken>()))
			.Returns(true)
			.Returns(false);

		//Mock FindAsync
		_mockCollection.Setup(op => op.FindAsync(It.IsAny<FilterDefinition<Ingredient>>(),
			It.IsAny<FindOptions<Ingredient,Ingredient>>(),
			It.IsAny<CancellationToken>()))
			.ReturnsAsync(_ingredientCursor.Object);

		//Mock GetCollection
		_mockContext.Setup(c => c.GetCollection<Ingredient>(typeof(Ingredient).Name)).Returns(_mockCollection.Object);
		 var ingredientRepo = new IngredientRepository(_mockContext.Object);

		var result = await ingredientRepo.GetAllAsync();

		foreach (Ingredient  ingredient in result)
		{
			Assert.NotNull(ingredient);
			Assert.Equal(ingredient.Name,_list.First().Name);
			break;
		}

		//verify the InsertOneAsync is called once
		_mockCollection.Verify(c => c.FindAsync(It.IsAny<FilterDefinition<Ingredient>>(),
			It.IsAny<FindOptions<Ingredient>>(),
			It.IsAny<CancellationToken>()),Times.Once);


	}
}

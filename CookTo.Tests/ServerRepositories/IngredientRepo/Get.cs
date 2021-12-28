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

public class Get
{
	private Mock<IMongoCollection<Ingredient>> _mockCollection;
	private Mock<ICookToDbContext> _mockContext;
	private Ingredient _ingredient;
	private List<Ingredient> _list;

	public Get()
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
	public async Task GetIngredientById_Valid_Success()
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

	[Theory]
	[InlineData(null)]
	[InlineData("")]
	public async Task GetIngredientById_InvalidID_ExceptionThrown_Success(string value)
	{
		//Mock GetCollection
		_mockContext.Setup(c => c.GetCollection<Ingredient>(typeof(Ingredient).Name)).Returns(_mockCollection.Object);
		var ingredientRepo = new IngredientRepository(_mockContext.Object);

		await Assert.ThrowsAsync<ArgumentNullException>(() => ingredientRepo.GetByIdAsync(value));
	}


	[Fact]
	public async Task GetIngredientById_Document_NotFound_ExceptionThrown_Success()
	{

		var id = "1234a1234b1234c1234d1233";
		List<Ingredient> list = null;
		//Mock MoveNextAsync
		Mock<IAsyncCursor<Ingredient>> _ingredientCursor = new Mock<IAsyncCursor<Ingredient>>();
		_ingredientCursor.Setup(_ => _.Current).Returns(list);
		_ingredientCursor.SetupSequence(_ => _.MoveNext(It.IsAny<CancellationToken>()))
			.Returns(true)
			.Returns(false);
		_mockCollection.Setup(op => op.FindAsync(It.IsAny<FilterDefinition<Ingredient>>(),
			It.IsAny<FindOptions<Ingredient, Ingredient>>(),
			It.IsAny<CancellationToken>()))
			.ReturnsAsync(_ingredientCursor.Object);

		//Mock GetCollection
		_mockContext.Setup(c => c.GetCollection<Ingredient>(typeof(Ingredient).Name)).Returns(_mockCollection.Object);
		var ingredientRepo = new IngredientRepository(_mockContext.Object);

		await Assert.ThrowsAsync<Exception>(() => ingredientRepo.GetByIdAsync(id));
	}

	[Fact]
	public async Task GetIngredientById_ThrowException_Failure()
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
	public async Task GetAllIngredientAsync_Valid_Success()
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

	[Fact]
	public async Task GetAllIngredientAsync_NoDocumentsFound_ExceptionThrown_Success()
	{
		List<Ingredient> list = null;
		//Mock MoveNextAsync
		Mock<IAsyncCursor<Ingredient>> _ingredientCursor = new Mock<IAsyncCursor<Ingredient>>();
		_ingredientCursor.Setup(_ => _.Current).Returns(list);
		_ingredientCursor.SetupSequence(_ => _.MoveNext(It.IsAny<CancellationToken>()))
			.Returns(true)
			.Returns(false);

		//Mock FindAsync
		_mockCollection.Setup(op => op.FindAsync(It.IsAny<FilterDefinition<Ingredient>>(),
			It.IsAny<FindOptions<Ingredient, Ingredient>>(),
			It.IsAny<CancellationToken>()))
			.ReturnsAsync(_ingredientCursor.Object);

		//Mock GetCollection
		_mockContext.Setup(c => c.GetCollection<Ingredient>(typeof(Ingredient).Name)).Returns(_mockCollection.Object);
		var ingredientRepo = new IngredientRepository(_mockContext.Object);

		await Assert.ThrowsAsync<Exception>(() => ingredientRepo.GetAllAsync());

		//verify the InsertOneAsync is called once
		_mockCollection.Verify(c => c.FindAsync(It.IsAny<FilterDefinition<Ingredient>>(),
			It.IsAny<FindOptions<Ingredient>>(),
			It.IsAny<CancellationToken>()), Times.Once);


	}

}

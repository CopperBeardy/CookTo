using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

public class Insert
{
	private Mock<IMongoCollection<Ingredient>> _mockCollection;
	private Mock<ICookToDbContext> _mockContext;
	
	public Insert()
	{
		_mockCollection = new Mock<IMongoCollection<Ingredient>>();
		_mockContext = new Mock<ICookToDbContext>();
	}

	[Fact]
	public async Task CreateIngredient_Valid_Success() 
	{
		var ingredient = new Ingredient()
		{
			Name = "Cheese"
		};

		_mockCollection.Setup(i =>
		i.InsertOneAsync(ingredient, null, default(CancellationToken)))
			.Returns(Task.CompletedTask);
		_mockContext.Setup(c => c.GetCollection<Ingredient>(typeof(Ingredient).Name))
			.Returns(_mockCollection.Object);

		var ingredientRepo = new IngredientRepository(_mockContext.Object);

		await ingredientRepo.CreateAsync(ingredient);

		_mockCollection.Verify(c => c.InsertOneAsync(ingredient,null, default(CancellationToken)),Times.Once);

	}

	[Fact]
	public async Task CreateIngredient_Null_Failure()
	{
		Ingredient ingredient = null;

		var ingredientRepo = new IngredientRepository(_mockContext.Object);

		await Assert.ThrowsAsync<ArgumentNullException>(() => ingredientRepo.CreateAsync(ingredient));
	}
}

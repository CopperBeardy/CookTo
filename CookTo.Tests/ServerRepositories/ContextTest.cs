using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookTo.Server.DbContext;
using CookTo.Shared.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Moq;
using Xunit;

namespace CookTo.Tests.ServerRepositories;

public  class ContextTest
{
	public Mock<IOptions<MongoSettings>> _mockOptions { get; set; }
	public Mock<IMongoDatabase> _mockDb { get; set; }
	public Mock<IMongoClient> _mockClient { get; set; }
	public ContextTest()
	{
		_mockOptions = new Mock<IOptions<MongoSettings>>();
		_mockClient = new Mock<IMongoClient>();
		_mockDb = new Mock<IMongoDatabase>();
	}
	[Fact]
	public void CookToDbContext_Construtor_Success()
	{
		var settings = new MongoSettings()
		{
			Connection = "mongodb://Test123",
			Database = "testDb"
		};

		_mockOptions.Setup(s => s.Value).Returns(settings);
		_mockClient.Setup(c => c.GetDatabase(_mockOptions.Object.Value.Database,null))
			.Returns(_mockDb.Object);

		var context = new CookToDbContext(_mockOptions.Object);


		Assert.NotNull(context);

	}
	[Fact]
	public void CookToDbContext_GetCollection_NameEmpty_Failure()
	{
		var settings = new MongoSettings()
		{
			Connection = "mongodb://Test123",
			Database = "testDb"
		};
		_mockOptions.Setup(s => s.Value).Returns(settings);
		_mockClient.Setup(c => c.GetDatabase(_mockOptions.Object.Value.Database, null))
			.Returns(_mockDb.Object);

		var context = new CookToDbContext(_mockOptions.Object);
		var collection = context.GetCollection<Ingredient>("");
		Assert.Null(collection);
	}
	[Fact]
	public void CookToDbContext_GetCollection_ValidName_Success()
	{
		var settings = new MongoSettings()
		{
			Connection = "mongodb://Test123",
			Database = "testDb"
		};
		_mockOptions.Setup(s => s.Value).Returns(settings);
		_mockClient.Setup(c => c.GetDatabase(_mockOptions.Object.Value.Database, null))
			.Returns(_mockDb.Object);

		var context = new CookToDbContext(_mockOptions.Object);
		var collection = context.GetCollection<Ingredient>("ingredients");
		Assert.NotNull(collection);
	}
}

﻿using MongoDB.Bson;

namespace CookTo.Tests.Intergration.BookmarksControllerTests;

public class BookmarksFixture : Fixture
{
	public ILogger<BookmarksController> logger;
	public IBookmarksService BookmarksService;
	public BookmarksController SUT;
	public List<Bookmarks> list;
	public string collectionName = nameof(Bookmarks);

	public BookmarksFixture()
	{
		var loggerFactory = new LoggerFactory();
		logger = loggerFactory.CreateLogger<BookmarksController>();
		BookmarksService = new BookmarksService(CookToDbContext);
		SUT = new BookmarksController(BookmarksService, logger);
	}

	public void SetupCollection()
	{
		var client = new MongoClient(connectionString);
		var database = client.GetDatabase(db);
		RemoveCollectionIfExists();
		database.CreateCollection(collectionName);

		var collection = CookToDbContext.GetCollection<Bookmarks>(nameof(Bookmarks));

		list = new List<Bookmarks>();

		list.Add(
			new Bookmarks
			{
				UserId = "1111a1111a1111a1111a1111",
				BookmarkedRecipes =
					new List<Bookmarked>()
						{
							new Bookmarked() { RecipeId = "id", Title = "Baked Alaska" },
							new Bookmarked() { RecipeId = "id", Title = "Cup Cakes" }
						}
			});
		list.Add(
			new Bookmarks
			{
				UserId = "1111b1111b1111b1111b1111",
				BookmarkedRecipes =
					new List<Bookmarked>()
						{
							new Bookmarked() { RecipeId = "id", Title = "Cheese Flan" },
							new Bookmarked() { RecipeId = "id", Title = "Sponge cake" }
						}
			});
		collection.InsertMany(list);
	}

	public void Dispose()
	{
		RemoveCollectionIfExists();
		GC.SuppressFinalize(this);
	}

	private void RemoveCollectionIfExists()
	{
		var client = new MongoClient(connectionString);
		var database = client.GetDatabase(db);
		var collections = database.ListCollectionNames().ToList();
		if(collections.Contains(collectionName))
		{
			database.DropCollection(collectionName);
		}
	}
}
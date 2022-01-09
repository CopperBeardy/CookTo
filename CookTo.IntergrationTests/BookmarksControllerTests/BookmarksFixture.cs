using MongoDB.Bson;
using System;
using System.Linq;

namespace CookTo.Tests.Intergration.BookmarksControllerTests;

public class BookmarksFixture : Fixture
{
	public ILogger<BookmarksController> logger;
	public IBookmarksService BookmarksService;
	public BookmarksController SUT;
	public List<Bookmarks> list;
	public BookmarksFixture()
	{
		SetupCollection("Bookmarks");
		var collection = CookToDbContext.GetCollection<Bookmarks>(nameof(Bookmarks));
		var loggerFactory = new LoggerFactory();
		logger = loggerFactory.CreateLogger<BookmarksController>();
		BookmarksService = new BookmarksService(CookToDbContext);
		SUT = new BookmarksController(BookmarksService, logger);
		list = new List<Bookmarks>();

		list.Add(new Bookmarks
		{
			UserId = "1111a1111a1111a1111a1111",
			BookmarkedRecipes = new List<Bookmarked>()
			{
				new Bookmarked()
				{
					RecipeId= ObjectId.GenerateNewId(),
					Title="Baked Alaska"
				},
				new Bookmarked()
				{
					RecipeId = ObjectId.GenerateNewId(),
					Title = "Cup Cakes"
				}
			}
		});
		list.Add(new Bookmarks
		{
			UserId = "1111b1111b1111b1111b1111",
			BookmarkedRecipes = new List<Bookmarked>()
			{
				new Bookmarked()
				{
					RecipeId= ObjectId.GenerateNewId(),
					Title="Cheese Flan"
				},
				new Bookmarked()
				{
					RecipeId = ObjectId.GenerateNewId(),
					Title = "Sponge cake"
				}
			}
		});
		collection.InsertMany(list);
	}
}
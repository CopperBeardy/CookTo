using System;
using System.Linq;

namespace CookTo.Tests.ServerControllerTests.BookmarkControllerTests;

public class BookmarksFixture
{

	public Mock<IBookmarksService> _mockService;
	public Mock<ICookToDbContext> _mockDbContext;
	public Mock<IMongoCollection<Bookmarks>> _mockCollection;
	public Mock<ILogger<BookmarksController>> _mockLogger;
	public Bookmarked _bookmarked;
	public Bookmarks _bookmarks;


	public BookmarksFixture()
	{
		_mockDbContext = new Mock<ICookToDbContext>();
		_mockCollection = new Mock<IMongoCollection<Bookmarks>>();
		_mockService = new Mock<IBookmarksService>();
		_mockLogger = new Mock<ILogger<BookmarksController>>();

		_bookmarks = 	new Bookmarks()
			{
				Id = new ObjectId("1111a1111b1111c1111d1111"),
				UserId = "7777a7777a7777a7777a7777", 
				BookmarkedRecipes = new List<Bookmarked>()
				{
					new Bookmarked()
					{
						RecipeId = new ObjectId("aaaa1aaaa2aaaa3aaaa4aaaa"),
						Title = "Bread"
					}  ,
					new Bookmarked()
					{
						RecipeId = new ObjectId("aaaa2aaaa5aaaa7aaaa8aaaa"),
						Title = "Milk"
					}
				}
		};
		_mockCollection.Object.InsertOne(_bookmarks);
		_bookmarked = new Bookmarked()
		{
			RecipeId = new ObjectId("3333a3333b3333c3333d3333"),
			Title = "Butter"
		};
	}
}


using CookTo.Tests.Server.Unit.TestDbContext;

namespace CookTo.Tests.Server.Unit.BookmarkControllerTests;

public class BookmarksFixture
{
	public Mock<IBookmarksService> _mockService;
	public Mock<ICookToDbContext> _mockDbContext;
	public Mock<IMongoCollection<Bookmarks>> _mockCollection;
	public Mock<ILogger<BookmarksController>> _mockLogger;
	public Bookmarked _bookmarked;
	public Bookmarks _bookmarks;
	public BookmarksController SUT;

	public BookmarksFixture()
	{
		_mockDbContext = new Mock<ICookToDbContext>();
		_mockCollection = new Mock<IMongoCollection<Bookmarks>>();
		_mockService = new Mock<IBookmarksService>();
		_mockLogger = new Mock<ILogger<BookmarksController>>();

		_bookmarks = new Bookmarks()
		{
			Id = "1111a1111b1111c1111d1111",
			UserId = "7777a7777a7777a7777a7777",
			BookmarkedRecipes =
				new List<Bookmarked>()
				{
					new Bookmarked() { RecipeId = "aaaa1aaaa2aaaa3aaaa4aaaa", Title = "Bread" },
					new Bookmarked() { RecipeId = "aaaa2aaaa5aaaa7aaaa8aaaa", Title = "Milk" }
				}
		};
		_mockCollection.Object.InsertOne(_bookmarks);
		_bookmarked = new Bookmarked() { RecipeId = "3333a3333b3333c3333d3333", Title = "Butter" };
		_mockDbContext.Setup(c => c.GetCollection<Bookmarks>(typeof(Bookmarks).Name)).Returns(_mockCollection.Object);
		SUT = new BookmarksController(_mockService.Object, _mockLogger.Object);
	}
}


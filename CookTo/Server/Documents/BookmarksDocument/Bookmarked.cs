namespace CookTo.Server.Documents.BookmarksDocument;

public partial class Bookmarks
{
    public class BookMarked
    {
        [BsonElement("bookmarkedrecipeid")]
        public string BookMarkedRecipeId { get; set; }

        [BsonElement("recipetitle")]
        public string RecipeTitle { get; set; }
    }
}


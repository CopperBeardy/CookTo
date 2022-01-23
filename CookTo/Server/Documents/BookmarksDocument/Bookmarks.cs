namespace CookTo.Server.Documents.BookmarksDocument;

public partial class Bookmarks : BaseEntity
{
    [BsonElement("userid")]
    public string UserId { get; set; }

    [BsonElement("bookmarkedrecipes")]
    public List<BookMarked>? BookMarkedRecipes { get; set; }
}


namespace CookTo.Server.Documents.BookmarksDocument;

public partial class Bookmarks : BaseEntity
{
    [BsonElement("user_id")]
    public string UserId { get; set; }

    [BsonElement("bookmarked_recipes")]
    public List<SectionBookMarked>? BookMarkedRecipes { get; set; }
}


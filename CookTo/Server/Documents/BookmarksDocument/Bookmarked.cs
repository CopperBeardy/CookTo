namespace CookTo.Server.Documents.BookmarksDocument;

public partial class Bookmarks
{
    public class BookMarked
    {
        [BsonElement("bookMarkedRecipeId")]
        public string BookMarkedRecipeId { get; set; }

        [BsonElement("recipeTitle")]
        public string RecipeTitle { get; set; }
    }
}


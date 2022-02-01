namespace CookTo.Server.Documents.BookmarksDocument;


public class SectionBookMarked
{
    [BsonElement("bookMarkedRecipeId")]
    public string BookMarkedRecipeId { get; set; }

    [BsonElement("recipeTitle")]
    public string RecipeTitle { get; set; }
}



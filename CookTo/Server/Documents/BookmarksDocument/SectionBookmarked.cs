namespace CookTo.Server.Documents.BookmarksDocument;


public class SectionBookMarked
{
    [BsonElement("bookmarked_recipe_id")]
    public string BookMarkedRecipeId { get; set; }

    [BsonElement("recipe_title")]
    public string RecipeTitle { get; set; }
}



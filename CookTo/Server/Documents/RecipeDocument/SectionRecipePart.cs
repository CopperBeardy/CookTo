namespace CookTo.Server.Documents.RecipeDocument;


public class SectionRecipePart
{
    [BsonElement("partTitle")]
    public string PartTitle { get; set; }

    [BsonElement("items")]
    public List<SectionPartIngredient> Items { get; set; }
}

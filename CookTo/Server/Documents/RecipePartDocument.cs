namespace CookTo.Server.Documents;


public class RecipePartDocument
{
    [BsonElement("part_title")]
    public string PartTitle { get; set; }

    [BsonElement("items")]
    public List<PartIngredientDocument> Items { get; set; }
}

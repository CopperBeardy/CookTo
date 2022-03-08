namespace CookTo.Server.Documents.IngredientDocument;

public class Ingredient : BaseEntity
{
    [BsonElement("name")]
    public string Name { get; set; }
}


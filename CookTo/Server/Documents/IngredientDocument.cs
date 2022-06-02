namespace CookTo.Server.Documents;

public class IngredientDocument : BaseDocument
{
    [BsonElement("name")]
    public string Name { get; set; }
}


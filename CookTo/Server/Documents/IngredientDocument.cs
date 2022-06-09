namespace CookTo.Server.Documents;

public class IngredientDocument : BaseDocument
{
    [BsonElement("text")]
    public string Text { get; set; }
}


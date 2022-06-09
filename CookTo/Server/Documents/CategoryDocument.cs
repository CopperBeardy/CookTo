namespace CookTo.Server.Documents;

public class CategoryDocument : BaseDocument
{
    [BsonElement("text")]
    public string Text { get; set; }
}

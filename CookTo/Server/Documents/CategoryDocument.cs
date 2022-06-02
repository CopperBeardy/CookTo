namespace CookTo.Server.Documents;

public class CategoryDocument : BaseDocument
{
    [BsonElement("name")]
    public string Name { get; set; }
}

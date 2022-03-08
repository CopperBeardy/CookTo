namespace CookTo.Server.Documents.CategoryDocument;

public class Category : BaseEntity
{
    [BsonElement("name")]
    public string Name { get; set; }
}

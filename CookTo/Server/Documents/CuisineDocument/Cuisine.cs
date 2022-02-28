namespace CookTo.Server.Documents.CuisineDocument;

public class Cuisine : BaseEntity
{
    [BsonElement("name")]
    public string Name { get; set; }
}


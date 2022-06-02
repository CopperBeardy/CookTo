namespace CookTo.Server.Documents;

public class CuisineDocument : BaseDocument
{
    [BsonElement("name")]
    public string Name { get; set; }
}


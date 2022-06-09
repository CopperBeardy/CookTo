namespace CookTo.Server.Documents;

public class CuisineDocument : BaseDocument
{
    [BsonElement("text")]
    public string Text { get; set; }
}


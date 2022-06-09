namespace CookTo.Server.Documents;

public class UtensilDocument : BaseDocument
{
    [BsonElement("text")]
    public string Text { get; set; }
}

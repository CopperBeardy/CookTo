namespace CookTo.Server.Documents;

public class UtensilDocument : BaseDocument
{
    [BsonElement("utensil_name")]
    public string UtensilName { get; set; }
}

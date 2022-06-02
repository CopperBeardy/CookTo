namespace CookTo.Server.Documents;

public class UtensilPartDocument
{
    [BsonElement("required_amount")]
    public int RequiredAmount { get; set; }

    [BsonElement("utensil")]
    public UtensilDocument Utensil { get; set; }
}

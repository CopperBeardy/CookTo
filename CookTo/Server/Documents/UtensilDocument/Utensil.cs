using System.Text.Json.Serialization;

namespace CookTo.Server.Documents.UtensilDocument;

public class Utensil : BaseEntity
{
    [BsonElement("requiredAmount")]
    public int RequiredAmount { get; set; }

    [BsonElement("utensilName")]
    public string UtensilName { get; set; }
}

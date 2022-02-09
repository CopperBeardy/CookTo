using MongoDB.Bson.Serialization.IdGenerators;
using System.Text.Json.Serialization;

namespace CookTo.Server.Documents.UtensilDocument;

public class Utensil : BaseEntity
{
    [BsonElement("required_amount")]
    public int RequiredAmount { get; set; }

    [BsonElement("utensil_name")]
    public string UtensilName { get; set; }
}

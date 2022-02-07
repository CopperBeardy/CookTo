using MongoDB.Bson.Serialization.IdGenerators;
using System.Text.Json.Serialization;

namespace CookTo.Server.Documents.UtensilDocument;

public class Utensil : BaseEntity
{
    [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [BsonElement("requiredAmount")]
    public int RequiredAmount { get; set; }

    [BsonElement("utensilName")]
    public string UtensilName { get; set; }
}

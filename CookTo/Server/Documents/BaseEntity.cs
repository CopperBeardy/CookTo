using MongoDB.Bson.Serialization.IdGenerators;
using System.Text.Json.Serialization;

namespace CookTo.Server.Documents;

public abstract class BaseEntity
{
    [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
    [JsonPropertyName("_id")]
    public string Id { get; set; }
}

using MongoDB.Bson.Serialization.IdGenerators;

namespace CookTo.Shared.Models;

public abstract class BaseEntity
{
    [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
    [JsonPropertyName("_id")]
    public string Id { get; set; }
}

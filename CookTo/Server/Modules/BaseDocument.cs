using MongoDB.Bson.Serialization.IdGenerators;
using System.Text.Json.Serialization;

namespace CookTo.Server.Modules;

public abstract class BaseDocument
{
    [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
    [JsonPropertyName("id")]
    public virtual  string? Id { get; set; }
}

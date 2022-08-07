using MongoDB.Bson.Serialization.IdGenerators;

namespace CookTo.Server.Modules;

public abstract class BaseDocument
{
    [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
    public string? Id { get; set; }
}

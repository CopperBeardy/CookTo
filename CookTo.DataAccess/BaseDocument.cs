using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace CookTo.DataAccess;

public abstract class BaseDocument
{
    [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
    public string? Id { get; set; }
}

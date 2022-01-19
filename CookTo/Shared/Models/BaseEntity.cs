using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace CookTo.Shared.Models;

public abstract class BaseEntity : ModelBase
{
	[BsonId(IdGenerator = typeof(StringObjectIdGenerator))]

	[JsonPropertyName("_id")]
	public string Id { get; set; }
}

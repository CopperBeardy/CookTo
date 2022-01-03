using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace CookTo.Shared.Models;

public abstract class BaseEntity  :ModelBase
{
	[BsonId(IdGenerator = typeof(ObjectIdGenerator))]
	[BsonRepresentation(BsonType.ObjectId)]
	public ObjectId? Id { get; set; }
}

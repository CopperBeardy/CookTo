using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace CookTo.Shared.Models;

public class Ingredient
{

	[BsonId]
	[BsonRepresentation(BsonType.ObjectId)]
	public ObjectId? Id { get; set; }

	public string Name { get; set; }
}

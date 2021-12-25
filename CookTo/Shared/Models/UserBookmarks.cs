using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CookTo.Shared.Models;

public class UserBookmarks
{
	[BsonId]
	[BsonRepresentation(BsonType.ObjectId)]
	public ObjectId Id { get; set; }

	public string UserId { get; set; }

	public List<List<ObjectId>>? BookmarkCollections { get; set; }

}


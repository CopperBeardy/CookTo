using System.Text.Json.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CookTo.Shared.Models;

public class UserBookmarks
{
	[BsonElement("_id")]
	[JsonPropertyName("_id")]
	[BsonId]
	[BsonRepresentation(BsonType.ObjectId)]
	public string UserBookmarksId { get; set; }

	public object UserId { get; set; }

	public List<BookmarkCollection>? BookmarkCollections { get; set; }

}


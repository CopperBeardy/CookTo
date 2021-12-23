using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace CookTo.Shared.Models;

public class BookmarkCollection
{
	[BsonElement("id")]
	[JsonPropertyName("id")]
	public object BookmarkCollectionId { get; set; }

	[BsonElement("title")]
	[BsonRequired]
	public string CollectionTitle { get; set; }
	[JsonIgnore]
	public List<ObjectId> Bookmarks { get; set; }
}


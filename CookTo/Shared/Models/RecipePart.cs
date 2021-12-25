using System.Text.Json.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace CookTo.Shared.Models;

public class RecipePart
 {
	[BsonElement("title")]
	[BsonRequired]
	public string Title { get; set; }
	public List<string> Ingredients { get; set; }

}




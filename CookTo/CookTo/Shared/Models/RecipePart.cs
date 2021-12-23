using System.Text.Json.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace CookTo.Shared.Models;

public class RecipePart
 {
	[BsonElement("id")]
	[JsonPropertyName("id")]
	public object RecipePartId { get; set; }
	[BsonElement("title")]
	[BsonRequired]
	public string Title { get; set; }
	public List<RecipeIngredient> Ingredients { get; set; }

}




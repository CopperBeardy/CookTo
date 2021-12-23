using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Linq;
using System.Text.Json.Serialization;

namespace CookTo.Shared.Models;

public class Ingredients
{
	[BsonElement("_id")]
	[JsonPropertyName("_id")]
	[BsonId]
	[BsonRepresentation(BsonType.ObjectId)]
	public string IngredientId { get; set; }

	public List<string> Names { get; set; }
}

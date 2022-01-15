
using CookTo.Shared.Rules;
using MongoDB.Bson.Serialization.Attributes;

namespace CookTo.Shared.Models;

public class RecipePart
{
	[BsonElement("title")]
	[BsonRequired]
	[RequiredRule]
	[MinLengthRule(5)]
	[JsonPropertyName("title")]
	public string Title { get; set; }

	public List<string> Items { get; set; }
}



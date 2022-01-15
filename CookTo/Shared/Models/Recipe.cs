using CookTo.Shared.Rules;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CookTo.Shared.Models;

public class Recipe : BaseEntity
{
	[BsonElement("title")]
	[BsonRequired]
	[RequiredRule]
	[MinLengthRule(5)]
	[JsonPropertyName("title")]
	public string Title { get; set; }

	[RequiredRule]
	[JsonPropertyName("category")]
	public string Category { get; set; }

	[RequiredRule]
	[MinLengthRule(40)]
	[JsonPropertyName("description")]
	public string Description { get; set; }

	[JsonPropertyName("imageurl")]
	public string? ImageUrl { get; set; }

	[JsonPropertyName("preptime")]
	public int PreparationTime { get; set; }

	[JsonPropertyName("cookingtime")]
	public int CookingTime { get; set; }

	[JsonPropertyName("serves")]
	public int Serves { get; set; }

	[BsonRequired]
	[BsonElement("author")]
	[JsonPropertyName("author")]
	public string AuthorId { get; set; }

	public List<RecipePart> RecipeParts { get; set; }

	public List<CookingStep> CookingSteps { get; set; }

	public List<string>? Tips { get; set; }
}



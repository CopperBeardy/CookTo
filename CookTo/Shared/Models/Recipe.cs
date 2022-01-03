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
	public string Title { get; set; }
	[RequiredRule]
	public string Category { get; set; }
	[RequiredRule]
	[MinLengthRule(40)]
	public string Description { get; set; }
	public string ImageUrl { get; set; }
	public int PrepartionTime { get; set; }
	public int CookingTime { get; set; }
	public int Serves { get; set; }
	[BsonRequired]
	[BsonElement("author")]
	public string AuthorId { get; set; }
	public List<RecipePart> RecipeParts { get; set; }
	public List<CookingStep> CookingSteps { get; set; }
	public List<string>? Tips { get; set; }

}




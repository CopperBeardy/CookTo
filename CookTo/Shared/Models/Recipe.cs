using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace CookTo.Shared.Models;

public class Recipe
{
	[BsonId]
	[BsonRepresentation(BsonType.ObjectId)]
	public ObjectId? Id { get; set; }
	[BsonElement("title")]
	[BsonRequired]
	public string Title { get; set; }
	public string Category { get; set; }
	public string Description { get; set; }
	public string ImageURL { get; set; }
	public string PrepartionTime { get; set; }
	public string CookingTime { get; set; }
	public int Serves { get; set; }
	[BsonRequired]
	[BsonElement("author")]
	public string AuthorId { get; set; }
	public List<RecipePart> RecipeParts { get; set; }
	public List<string>? CookingSteps { get; set; }
	public List<string>? Tips { get; set; }

}




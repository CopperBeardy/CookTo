using MongoDB.Bson.Serialization.Attributes;
namespace CookTo.Shared.Models;

public class Ingredient : BaseEntity
{
	[BsonRequired]
	public string Name { get; set; }
}

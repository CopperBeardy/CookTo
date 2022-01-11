using System.Text.Json.Serialization;
using CookTo.Shared.Rules;
using MongoDB.Bson.Serialization.Attributes;
namespace CookTo.Shared.Models;

public class Ingredient : BaseEntity
{
	[JsonInclude]
	[BsonRequired]
	[RequiredRule]
	[MinLengthRule(2)]
	public string Name { get; set; }

}

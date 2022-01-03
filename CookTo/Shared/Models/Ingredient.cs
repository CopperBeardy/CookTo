using System.ComponentModel.DataAnnotations;
using CookTo.Shared.Rules;
using MongoDB.Bson.Serialization.Attributes;
namespace CookTo.Shared.Models;

public class Ingredient : BaseEntity
{
	[BsonRequired]
	[RequiredRule]
	[MinLengthRule(2)]
	public string Name { get; set; }
}

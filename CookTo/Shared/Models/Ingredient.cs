
namespace CookTo.Shared.Models;

public class Ingredient : BaseEntity
{
	[JsonInclude]
	[BsonRequired]
	[RequiredRule]
	[MinLengthRule(2)]
	[JsonPropertyName("name")]
	public string Name { get; set; }
}

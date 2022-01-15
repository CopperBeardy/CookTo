using CookTo.Shared.Rules;
using MongoDB.Bson;

namespace CookTo.Shared.Models;

public class Bookmarked
{
	[RequiredRule]
	[JsonPropertyName("recipeId")]
	public string RecipeId { get; set; }

	[RequiredRule]
	[JsonPropertyName("title")]
	public string Title { get; set; }
}

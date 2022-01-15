using CookTo.Shared.Rules;
using System.Text.Json.Serialization;

namespace CookTo.Shared.Models;

public class Bookmarks : BaseEntity
{
	[RequiredRule]
	[JsonPropertyName("userid")]
	public string UserId { get; set; }

	public List<Bookmarked>? BookmarkedRecipes { get; set; }
}
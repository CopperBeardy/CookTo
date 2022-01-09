using CookTo.Shared.Rules;

namespace CookTo.Shared.Models;

public class Bookmarks : BaseEntity
{
	[RequiredRule]
	public string UserId { get; set; }
	public List<Bookmarked>? BookmarkedRecipes { get; set; }
}
using MongoDB.Bson;
namespace CookTo.Shared.Models;

public class Bookmarks : BaseEntity
{
	public string UserId { get; set; }

	public List<Bookmarked>? BookmarkedRecipes { get; set; }

}
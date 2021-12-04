using System.Text.Json.Serialization;

namespace CookTo.Shared.Models;

public class UserBookmarks
{
	public int UserBookmarksId { get; set; }

	public string UserId { get; set; }

	public List<BookmarkCollection>? BookmarkCollections { get; set; }

	public string CreationDate { get; set; }
}


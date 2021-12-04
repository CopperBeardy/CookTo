using CookTo.Shared.Models;
using System.Text.Json.Serialization;

namespace CookTo.Shared.Models;

public class BookmarkCollection
{
	public int BookmarkCollectionId { get; set; }
	public int UserBookmarksId { get; set; }
	public List<Bookmark> Bookmarks { get; set; }	   	
	public string CreationDate { get; set; }
}


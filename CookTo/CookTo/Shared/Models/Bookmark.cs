using System.Text.Json.Serialization;

namespace CookTo.Shared.Models;

	public class Bookmark
	{
	public int BookmarkId { get; set; }
	public int BookmarkCollectionId { get; set; }
	public int RecipeId { get; set; }
	public string CreationDate { get; set; }
	}


namespace CookTo.Shared.Features.ManageBookmarks;

public class BookmarksDto
{
    [JsonPropertyName("user_id")]
    public string UserId { get; set; } = string.Empty;

    [JsonPropertyName("bookmarked_recipes")]
    public List<BookMarked>? BookMarkedRecipes { get; set; }
}

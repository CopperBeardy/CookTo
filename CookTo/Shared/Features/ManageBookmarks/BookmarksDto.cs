namespace CookTo.Shared.Features.ManageBookmarks;

public partial class BookmarksDto
{
    [JsonPropertyName("_id")]
    public string Id { get; set; }

    [JsonPropertyName("userid")]
    public string UserId { get; set; } = string.Empty;

    [JsonPropertyName("bookmarkedrecipes")]
    public List<BookMarked>? BookMarkedRecipes { get; set; }
}

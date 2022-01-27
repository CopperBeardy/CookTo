namespace CookTo.Shared.Features.ManageBookmarks;

public class AddBookmarksDto
{
    [JsonPropertyName("userId")]
    public string UserId { get; set; } = string.Empty;

    [JsonPropertyName("bookMarkedRecipes")]
    public List<BookMarked>? BookMarkedRecipes { get; set; }
}

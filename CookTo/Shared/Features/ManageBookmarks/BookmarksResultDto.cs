namespace CookTo.Shared.Features.ManageBookmarks;

public  class BookmarksResultDto
{
    [JsonPropertyName("_id")]
    public string Id { get; set; }

    [JsonPropertyName("userId")]
    public string UserId { get; set; } = string.Empty;

    [JsonPropertyName("bookMarkedRecipes")]
    public List<BookMarked>? BookMarkedRecipes { get; set; }
}

using CookTo.Shared.Models;


namespace CookTo.Shared.Features.ManageBookmarks;

public partial class BookmarksDto : BaseEntity
{
    [JsonPropertyName("userid")]
    public string UserId { get; set; } = string.Empty;

    [JsonPropertyName("bookmarkedrecipes")]
    public List<BookMarked>? BookMarkedRecipes { get; set; }
}

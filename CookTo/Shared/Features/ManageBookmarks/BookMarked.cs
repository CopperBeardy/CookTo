namespace CookTo.Shared.Features.ManageBookmarks;

public partial class BookmarksDto
{
    public class BookMarked
    {
        [JsonPropertyName("bookmarkedrecipeid")]
        public string BookMarkedRecipeId { get; set; }

        [JsonPropertyName("recipetitle")]
        public string RecipeTitle { get; set; }
    }
}

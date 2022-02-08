namespace CookTo.Shared.Features.ManageBookmarks.Shared;

public class BookMarked
{
    [JsonPropertyName("bookMarkedRecipeId")]
    public string BookMarkedRecipeId { get; set; } = string.Empty;

    [JsonPropertyName("recipeTitle")]
    public string RecipeTitle { get; set; } = string.Empty;
}

namespace CookTo.Shared.Features.ManageBookmarks;

public class BookMarked
{
    [JsonPropertyName("_id")]
    public string? Id { get; set; } = string.Empty;


    [JsonPropertyName("bookmarked_recipe_id")]
    public string BookMarkedRecipeId { get; set; } = string.Empty;

    [JsonPropertyName("recipeTitle")]
    public string RecipeTitle { get; set; } = string.Empty;
}

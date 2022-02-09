using CookTo.Shared.Enums;

namespace CookTo.Shared.Features.ManageRecipes;

public class RecipeDto
{
    [JsonPropertyName("_id")]
    public string? Id { get; set; } = string.Empty;

    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;

    [JsonPropertyName("category")]
    public Category Category { get; set; } = Category.Baking;

    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;

    [JsonPropertyName("image")]
    public string? Image { get; set; } = string.Empty;

    [JsonPropertyName("prep_time")]
    public int PreparationTime { get; set; }

    [JsonPropertyName("cooking_time")]
    public int CookingTime { get; set; } = 0;

    [JsonPropertyName("serves")]
    public int Serves { get; set; } = 0;

    [JsonPropertyName("author")]
    public string AuthorId { get; set; } = string.Empty;

    [JsonPropertyName("recipe_parts")]
    public List<RecipePart> RecipeParts { get; set; } = new List<RecipePart>();

    [JsonPropertyName("utensils")]
    public List<UtensilPart> Utensils { get; set; } = new List<UtensilPart>();

    [JsonPropertyName("cooking_steps")]
    public List<CookingStep> CookingSteps { get; set; } = new List<CookingStep>();

    [JsonPropertyName("tips")]
    public List<string>? Tips { get; set; } = new List<string>();

    [JsonPropertyName("image_action")]
    public ImageAction ImageAction { get; set; }
}

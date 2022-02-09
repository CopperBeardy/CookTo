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

    [JsonPropertyName("prepTime")]
    public int PreparationTime { get; set; }

    [JsonPropertyName("cookingTime")]
    public int CookingTime { get; set; } = 0;

    [JsonPropertyName("serves")]
    public int Serves { get; set; } = 0;

    [JsonPropertyName("author")]
    public string AuthorId { get; set; } = string.Empty;

    [JsonPropertyName("recipeParts")]
    public List<RecipePart> RecipeParts { get; set; } = new List<RecipePart>();

    [JsonPropertyName("utensils")]
    public List<UtensilPart> Utensils { get; set; } = new List<UtensilPart>();

    [JsonPropertyName("cooking_steps")]
    public List<CookingStep> CookingSteps { get; set; } = new List<CookingStep>();

    [JsonPropertyName("tips")]
    public List<string>? Tips { get; set; } = new List<string>();
    [JsonPropertyName("imageAction")]

    public ImageAction ImageAction { get; set; }
}

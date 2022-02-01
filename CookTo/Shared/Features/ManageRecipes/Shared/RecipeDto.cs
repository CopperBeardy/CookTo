using CookTo.Shared.Enums;


namespace CookTo.Shared.Features.ManageRecipes.Shared;

public class RecipeDto
{
    [JsonPropertyName("_id")]
    public string Id { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("category")]
    public Category Category { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("image")]
    public string? Image { get; set; }

    [JsonPropertyName("prepTime")]
    public int PreparationTime { get; set; }

    [JsonPropertyName("cookingTime")]
    public int CookingTime { get; set; }

    [JsonPropertyName("serves")]
    public int Serves { get; set; }

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

    public ImageAction ImageAction { get; set; }
}

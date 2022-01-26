using CookTo.Shared.Enums;


namespace CookTo.Shared.Features.ManageRecipes;

public class RecipeResultDto
{
    [JsonPropertyName("_id")]
    public string Id { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;

    [JsonPropertyName("category")]
    public Category Category { get; set; } = Category.Baking;

    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;

    [JsonPropertyName("imageurl")]
    public string? ImageUrl { get; set; } = string.Empty;

    [JsonPropertyName("preptime")]
    public int PreparationTime { get; set; } = 0;

    [JsonPropertyName("cookingtime")]
    public int CookingTime { get; set; } = 0;

    [JsonPropertyName("serves")]
    public int Serves { get; set; } = 0;

    [JsonPropertyName("author")]
    public string AuthorId { get; set; } = string.Empty;

    [JsonPropertyName("recipeparts")]
    public List<RecipePart> RecipeParts { get; set; } = new List<RecipePart>();

    [JsonPropertyName("cookingsteps")]
    public List<CookingStep> CookingSteps { get; set; } = new List<CookingStep>();

    [JsonPropertyName("tips")]
    public List<string>? Tips { get; set; } = new List<string>();
}

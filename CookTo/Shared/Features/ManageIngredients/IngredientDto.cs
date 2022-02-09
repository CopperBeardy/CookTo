namespace CookTo.Shared.Features.ManageIngredients;

public class IngredientDto
{
    [JsonPropertyName("id")]
    public string? Id { get; set; } = string.Empty;


    [JsonPropertyName("name")]
    public string Name { get; set; }
}

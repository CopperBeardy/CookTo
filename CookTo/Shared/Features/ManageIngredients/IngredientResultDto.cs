namespace CookTo.Shared.Features.ManageIngredients;

public class IngredientResultDto
{
    [JsonPropertyName("_id")]
    public string Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
}

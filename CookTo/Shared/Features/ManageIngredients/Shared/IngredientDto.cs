namespace CookTo.Shared.Features.ManageIngredients.Shared;

public class IngredientDto
{
    [JsonPropertyName("_id")]
    public string Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }
}

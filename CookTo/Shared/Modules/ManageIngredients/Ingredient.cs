using System.Text.Json.Serialization;

namespace CookTo.Shared.Modules.ManageIngredients;

public class Ingredient
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
}

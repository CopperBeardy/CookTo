using System.Text.Json.Serialization;

namespace CookTo.Shared.Modules.ManageCuisines;

public class Cuisine
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
}

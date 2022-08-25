using System.Text.Json.Serialization;

namespace CookTo.Shared.Modules.ManageUtensils;

public class Utensil
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
}

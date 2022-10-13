using System.Text.Json.Serialization;

namespace CookTo.Shared.Models.ManageCuisines;

public sealed class Cuisine : BaseEntity
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
}

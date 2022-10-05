using System.Text.Json.Serialization;

namespace CookTo.Shared.Models.ManageCuisines;

public class Cuisine : BaseEntity
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
}

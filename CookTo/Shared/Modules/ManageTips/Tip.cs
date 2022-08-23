using System.Text.Json.Serialization;

namespace CookTo.Shared.Modules.ManageTips;

public class Tip
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;
}

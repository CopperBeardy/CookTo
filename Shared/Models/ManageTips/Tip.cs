using System.Text.Json.Serialization;

namespace CookTo.Shared.Models.ManageTips;

public sealed class Tip : BaseEntity
{
    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;
}

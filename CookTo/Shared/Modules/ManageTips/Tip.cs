using System.Text.Json.Serialization;

namespace CookTo.Shared.Modules.ManageTips;

public class Tip : BaseEntity
{
    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;
}

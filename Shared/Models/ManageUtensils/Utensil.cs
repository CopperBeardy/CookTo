using System.Text.Json.Serialization;

namespace CookTo.Shared.Models.ManageUtensils;

public sealed class Utensil : BaseEntity
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
}

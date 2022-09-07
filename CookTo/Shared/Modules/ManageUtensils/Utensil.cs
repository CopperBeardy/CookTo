using System.Text.Json.Serialization;

namespace CookTo.Shared.Modules.ManageUtensils;

public class Utensil : BaseEntity
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
}

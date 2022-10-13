
using System.Text.Json.Serialization;

namespace CookTo.Shared.Models.ManageCategories;

public sealed class Category : BaseEntity
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
}

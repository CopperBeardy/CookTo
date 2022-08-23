
using System.Text.Json.Serialization;

namespace CookTo.Shared.Modules.ManageCategories;

public class Category
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
}

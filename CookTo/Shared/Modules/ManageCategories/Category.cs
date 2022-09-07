
using System.Text.Json.Serialization;

namespace CookTo.Shared.Modules.ManageCategories;

public class Category : BaseEntity
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
}

using System.Text.Json.Serialization;

namespace CookTo.Shared.Modules.ManageIngredients;

public class Ingredient : BaseEntity
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
}

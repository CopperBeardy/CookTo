using CookTo.Shared.Models;

namespace CookTo.Shared.Features.ManageIngredients;

public class IngredientDto : BaseEntity
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
}

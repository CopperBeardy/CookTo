namespace CookTo.Shared.Features.ManageRecipes.Shared;


public class RecipePart
{
    [JsonPropertyName("partTitle")]
    public string PartTitle { get; set; } = string.Empty;

    [JsonPropertyName("items")]
    public List<PartIngredient> Items { get; set; } = new List<PartIngredient>();
}


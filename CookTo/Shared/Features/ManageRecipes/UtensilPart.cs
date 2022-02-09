namespace CookTo.Shared.Features.ManageRecipes;

public class UtensilPart
{
    [JsonPropertyName("required_amount")]
    public int RequiredAmount { get; set; } = 0;

    [JsonPropertyName("utensil_name")]
    public string UtensilName { get; set; } = string.Empty;
}

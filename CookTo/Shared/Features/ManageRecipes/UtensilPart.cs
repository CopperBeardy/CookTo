namespace CookTo.Shared.Features.ManageRecipes;

public class UtensilPart
{
    [JsonPropertyName("requiredAmount")]
    public int RequiredAmount { get; set; } = 0;

    [JsonPropertyName("utensilName")]
    public string UtensilName { get; set; } = string.Empty;
}

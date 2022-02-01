namespace CookTo.Shared.Features.ManageRecipes.Shared;

public class UtensilPart
{
    [JsonPropertyName("requiredAmount")]
    public int RequiredAmount { get; set; }

    [JsonPropertyName("utensilName")]
    public string UtensilName { get; set; }
}

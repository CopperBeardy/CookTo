

namespace CookTo.Shared.Features.ManageUtensils;

public class AddUtensilDto
{
    [JsonPropertyName("requiredAmount")]
    public int RequiredAmount { get; set; }

    [JsonPropertyName("utensilName")]
    public string UtensilName { get; set; }
}

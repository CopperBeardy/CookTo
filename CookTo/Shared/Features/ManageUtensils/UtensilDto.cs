namespace CookTo.Shared.Features.ManageUtensils;

public class UtensilDto
{
    [JsonPropertyName("_id")]
    public string? Id { get; set; } = string.Empty;


    [JsonPropertyName("utensil_name")]
    public string UtensilName { get; set; }
}



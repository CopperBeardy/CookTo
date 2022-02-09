namespace CookTo.Shared.Features.ManageUtensils;

public class UtensilDto
{
    [JsonPropertyName("_id")]
    public string Id { get; set; }

    [JsonPropertyName("utensilName")]
    public string UtensilName { get; set; }
}



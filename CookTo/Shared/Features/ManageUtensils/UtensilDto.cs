namespace CookTo.Shared.Features.ManageUtensils;

public class UtensilDto
{
    [JsonProperty("_id")]
    public string? Id { get; set; }


    [JsonProperty("utensil_name")]
    public string UtensilName { get; set; }
}



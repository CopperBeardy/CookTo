namespace CookTo.Shared.Features.ManageIngredients;

public class AddIngredientDto
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
}

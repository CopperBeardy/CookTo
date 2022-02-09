namespace CookTo.Shared.Features.ManageRecipes;


public class CookingStep
{
    [JsonPropertyName("step_order_number")]
    public int OrderNumber { get; set; } = 0;


    [JsonPropertyName("step")]
    public string StepDescription { get; set; } = string.Empty;
}

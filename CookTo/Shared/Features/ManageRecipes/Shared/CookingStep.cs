namespace CookTo.Shared.Features.ManageRecipes.Shared;


public class CookingStep
{
    [JsonPropertyName("step_order_number")]
    public int OrderNumber { get; set; }


    [JsonPropertyName("step")]
    public string StepDescription { get; set; }
}

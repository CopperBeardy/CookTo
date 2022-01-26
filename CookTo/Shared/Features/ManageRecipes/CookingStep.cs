namespace CookTo.Shared.Features.ManageRecipes;


    public class CookingStep
    {
        [JsonPropertyName("stepordernumber")]
        public int OrderNumber { get; set; } = 0;

        [JsonPropertyName("step")]
        public string StepDescription { get; set; } = string.Empty;
    }

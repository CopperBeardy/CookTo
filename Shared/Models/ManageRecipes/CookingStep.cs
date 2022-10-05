namespace CookTo.Shared.Models.ManageRecipes;

public class CookingStep
{
    public int OrderNumber { get; set; }

    public string StepDescription { get; set; } = string.Empty;

    public List<CookingStepIngredient> CookingStepIngredients { get; set; } = new List<CookingStepIngredient>();
}

namespace CookTo.Shared.Modules.ManageRecipes;

public class CookingStep
{
    public int OrderNumber { get; set; }
    public string StepDescription { get; set; } = string.Empty;
    public List<StepIngredient> StepIngredients { get; set; } = new List<StepIngredient>();
}

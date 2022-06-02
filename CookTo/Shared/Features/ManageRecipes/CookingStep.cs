namespace CookTo.Shared.Features.ManageRecipes;

public class CookingStep
{
    public int OrderNumber { get; set; }
    public string StepDescription { get; set; }
    public List<PartIngredient> PartIngredients { get; set; }
}

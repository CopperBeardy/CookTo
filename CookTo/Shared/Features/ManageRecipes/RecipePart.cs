namespace CookTo.Shared.Features.ManageRecipes;

public class RecipePart
{
    public string PartTitle { get; set; }

    public List<PartIngredient> Ingredients { get; set; } = new List<PartIngredient>();

    public List<CookingStep> CookingSteps { get; set; } = new List<CookingStep>();
}


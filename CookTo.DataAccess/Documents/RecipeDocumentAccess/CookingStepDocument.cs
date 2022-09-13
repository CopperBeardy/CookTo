namespace CookTo.DataAccess.Documents.RecipeDocumentAccess;


public class CookingStepDocument
{
    public int OrderNumber { get; set; }

    public string StepDescription { get; set; } = string.Empty;

    public List<CookingStepIngredientDocument>? CookingStepIngredients { get; set; }
}


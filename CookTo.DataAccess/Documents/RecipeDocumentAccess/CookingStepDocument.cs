using MongoDB.Bson.Serialization.Attributes;

namespace CookTo.DataAccess.Documents.RecipeDocumentAccess;


public class CookingStepDocument
{
    public int OrderNumber { get; set; }

    public string? StepDescription { get; set; }

    public List<StepIngredientDocument>? StepIngredients { get; set; }
}


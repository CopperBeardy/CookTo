namespace CookTo.Server.Documents.RecipeDocument;

public partial class Recipe
{
    public class CookingStep
    {
        [BsonElement("stepOrderNumber")]
        public int OrderNumber { get; set; }

        [BsonElement("step")]
        public string StepDescription { get; set; }
    }
}

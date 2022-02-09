namespace CookTo.Server.Documents.RecipeDocument;


public class SectionCookingStep
{
    [BsonElement("step_order_number")]
    public int OrderNumber { get; set; }

    [BsonElement("step")]
    public string StepDescription { get; set; }
}


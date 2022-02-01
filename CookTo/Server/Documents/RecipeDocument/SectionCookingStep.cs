namespace CookTo.Server.Documents.RecipeDocument;


public class SectionCookingStep
{
    [BsonElement("stepOrderNumber")]
    public int OrderNumber { get; set; }

    [BsonElement("step")]
    public string StepDescription { get; set; }
}


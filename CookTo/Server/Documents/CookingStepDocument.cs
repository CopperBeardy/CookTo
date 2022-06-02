namespace CookTo.Server.Documents;


public class CookingStepDocument
{
    [BsonElement("step_order_number")]
    public int OrderNumber { get; set; }

    [BsonElement("step")]
    public string StepDescription { get; set; }

    [BsonElement("method_ingredients")]
    public List<PartIngredientDocument> MethodIngredients { get; set; }
}


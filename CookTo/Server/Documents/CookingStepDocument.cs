namespace CookTo.Server.Documents;


public class CookingStepDocument
{
    [BsonElement("step_order_number")]
    public int OrderNumber { get; set; }

    [BsonElement("step")]
    public string StepDescription { get; set; }

    [BsonElement("part_ingredients")]
    public List<StepIngredientDocument> StepIngredients { get; set; }
}


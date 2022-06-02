namespace CookTo.Server.Documents;

public class PartIngredientDocument
{
    [BsonElement("amount")]
    public double Amount { get; set; }

    [BsonElement("id")]
    public int Id { get; set; }

    [BsonElement("unit")]
    public MeasureUnit Unit { get; set; }

    [BsonElement("ingredient")]
    public IngredientDocument Ingredient { get; set; }

    [BsonElement("additional_information")]
    public string? AdditionalInformation { get; set; }


}

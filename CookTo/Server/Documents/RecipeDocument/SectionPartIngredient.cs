namespace CookTo.Server.Documents.RecipeDocument;


public class SectionPartIngredient
{
    [BsonElement("amount")]
    public double? Amount { get; set; }

    [BsonElement("unit")]
    public MeasureUnit Unit { get; set; }

    [BsonElement("ingredient_name")]
    public string IngredientName { get; set; }

    [BsonElement("additional_information")]
    public string? AdditionalInformation { get; set; }
}

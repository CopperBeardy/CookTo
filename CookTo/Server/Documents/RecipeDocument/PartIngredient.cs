namespace CookTo.Server.Documents.RecipeDocument;

public partial class Recipe
{
    public partial class RecipePart
    {
        public class PartIngredient
        {
            [BsonElement("amount")]
            public double? Amount { get; set; }

            [BsonElement("unit")]
            public MeasureUnit Unit { get; set; }

            [BsonElement(nameof(IngredientName))]
            public string IngredientName { get; set; }

            [BsonElement("additionalInformation")]
            public string? AdditionalInformation { get; set; }
        }
    }
}
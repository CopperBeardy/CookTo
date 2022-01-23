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

            [BsonElement("partingredientname")]
            public string PartIngredientName { get; set; }

            [BsonElement("partingredientdescription")]
            public string? PartIngredientDescription { get; set; }
        }
    }
}
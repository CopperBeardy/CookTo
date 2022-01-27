namespace CookTo.Server.Documents.RecipeDocument;

public partial class Recipe
{
    public partial class RecipePart
    {
        [BsonElement("partTitle")]
        public string PartTitle { get; set; }

        [BsonElement("items")]
        public List<PartIngredient> Items { get; set; }
    }
}
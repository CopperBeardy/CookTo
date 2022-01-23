namespace CookTo.Server.Documents.RecipeDocument;

public partial class Recipe : BaseEntity
{
    [BsonElement("title")]
    public string Title { get; set; }

    [BsonElement("category")]
    public Category Category { get; set; }

    [BsonElement("description")]
    public string Description { get; set; }

    [BsonElement("imageurl")]
    public string? ImageUrl { get; set; }

    [BsonElement("preptime")]
    public int PreparationTime { get; set; }

    [BsonElement("cookingtime")]
    public int CookingTime { get; set; }

    [BsonElement("serves")]
    public int Serves { get; set; }

    [BsonElement("author")]
    public string AuthorId { get; set; }

    [BsonElement("recipeparts")]
    public List<RecipePart> RecipeParts { get; set; }

    [BsonElement("cookingsteps")]
    public List<CookingStep> CookingSteps { get; set; }

    [BsonElement("tips")]
    public List<string>? Tips { get; set; }
}


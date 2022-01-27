using CookTo.Server.Documents.UtensilDocument;

namespace CookTo.Server.Documents.RecipeDocument;

public partial class Recipe : BaseEntity
{
    [BsonElement("title")]
    public string Title { get; set; }

    [BsonElement("category")]
    public Category Category { get; set; }

    [BsonElement("description")]
    public string Description { get; set; }

    [BsonElement("imageUrl")]
    public string? ImageUrl { get; set; }

    [BsonElement("prepTime")]
    public int PreparationTime { get; set; }

    [BsonElement("cookingTime")]
    public int CookingTime { get; set; }

    [BsonElement("serves")]
    public int Serves { get; set; }

    [BsonElement("author")]
    public string AuthorId { get; set; }

    [BsonElement("recipeParts")]
    public List<RecipePart> RecipeParts { get; set; }

    [BsonElement("utensils")]
    public List<Utensil> Utensils { get; set; }

    [BsonElement("cookingSteps")]
    public List<CookingStep> CookingSteps { get; set; }

    [BsonElement("tips")]
    public List<string>? Tips { get; set; }
}


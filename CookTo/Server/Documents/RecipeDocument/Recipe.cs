using MongoDB.Bson.Serialization.IdGenerators;
using System.Text.Json.Serialization;

namespace CookTo.Server.Documents.RecipeDocument;

public class Recipe : BaseEntity
{
    [BsonElement("title")]
    public string Title { get; set; }

    [BsonElement("category")]
    public Category Category { get; set; }

    [BsonElement("description")]
    public string Description { get; set; }

    [BsonElement("image")]
    public string? Image { get; set; }

    [BsonElement("prep_time")]
    public int PreparationTime { get; set; }

    [BsonElement("cooking_time")]
    public int CookingTime { get; set; }

    [BsonElement("serves")]
    public int Serves { get; set; }

    [BsonElement("author")]
    public string AuthorId { get; set; }

    [BsonElement("recipe_parts")]
    public List<SectionRecipePart> RecipeParts { get; set; }

    [BsonElement("utensils")]
    public List<SectionUtensilPart> Utensils { get; set; }

    [BsonElement("cooking_steps")]
    public List<SectionCookingStep> CookingSteps { get; set; }

    [BsonElement("tips")]
    public List<string>? Tips { get; set; }
}


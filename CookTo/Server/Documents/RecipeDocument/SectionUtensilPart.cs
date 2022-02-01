namespace CookTo.Server.Documents.RecipeDocument;

public class SectionUtensilPart
{
    [BsonElement("requiredAmount")]
    public int RequiredAmount { get; set; }

    [BsonElement("utensilName")]
    public string UtensilName { get; set; }
}

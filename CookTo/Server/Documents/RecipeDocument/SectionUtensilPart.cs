namespace CookTo.Server.Documents.RecipeDocument;

public class SectionUtensilPart
{
    [BsonElement("required_amount")]
    public int RequiredAmount { get; set; }

    [BsonElement("utensil_name")]
    public string UtensilName { get; set; }
}

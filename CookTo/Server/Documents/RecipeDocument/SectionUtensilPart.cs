using CookTo.Server.Documents.UtensilDocument;

namespace CookTo.Server.Documents.RecipeDocument;

public class SectionUtensilPart
{
    [BsonElement("required_amount")]
    public int RequiredAmount { get; set; }

    [BsonElement("utensil")]
    public Utensil Utensil { get; set; }
}

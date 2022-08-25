using CookTo.DataAccess.Documents.UtensilDocumentAccess;

namespace CookTo.DataAccess.Documents.RecipeDocumentAccess;

public class UtensilPartDocument
{
    public int RequiredAmount { get; set; }

    public UtensilDocument Utensil { get; set; }
}

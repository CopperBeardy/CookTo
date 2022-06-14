using CookTo.Server.Modules.Utensils.Core;

namespace CookTo.Server.Modules.Recipes.Core;

public class UtensilPartDocument
{
    [BsonElement("required_amount")]
    public int RequiredAmount { get; set; }

    [BsonElement("utensil")]
    public UtensilDocument? Utensil { get; set; }
}

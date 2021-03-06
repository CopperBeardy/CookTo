using CookTo.Server.Modules.Ingredients.Core;

namespace CookTo.Server.Modules.Recipes.Core;

public class StepIngredientDocument
{
    [BsonElement("quantity")]
    public string Quantity { get; set; }

    [BsonElement("measure")]
    public string  Measure { get; set; }

    [BsonElement("id")]
    public int Id { get; set; }

    [BsonElement("ingredient")]
    public string Ingredient { get; set; }
}

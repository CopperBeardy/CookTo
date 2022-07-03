using CookTo.Server.Modules.Ingredients.Core;

namespace CookTo.Server.Modules.Recipes.Core;

public class ShoppingItemDocument
{
    [BsonElement("quantity")]
    public string Quantity { get; set; }

    [BsonElement("measure")]
    public string  Measure { get; set; }

    [BsonElement("id")]
    public int Id { get; set; }

    [BsonElement("ingredient")]
    public IngredientDocument? Ingredient { get; set; }

    [BsonElement("additional_information")]
    public string? AdditionalInformation { get; set; }
}

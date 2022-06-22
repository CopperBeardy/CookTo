using CookTo.Server.Modules;

namespace CookTo.Server.Modules.Ingredients.Core;

public class IngredientDocument : BaseDocument
{
    [BsonElement("text")]
    public string? Text { get; set; }
}


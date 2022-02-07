using MongoDB.Bson.Serialization.IdGenerators;
using System.Text.Json.Serialization;

namespace CookTo.Server.Documents.IngredientDocument;

public class Ingredient : BaseEntity
{
    [BsonElement("name")]
    public string Name { get; set; }
}


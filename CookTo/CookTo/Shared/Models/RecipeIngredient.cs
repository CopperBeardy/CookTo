using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CookTo.Shared.Models;

public class RecipeIngredient
{
    [BsonElement("id")]
    [JsonPropertyName("id")]
    public object IngredientId { get; set; }
    [BsonRequired]
    [BsonElement("measure")]
    public string Measure { get; set; }
    [BsonRequired]
    public string Ingredient { get; set; }
    [BsonRequired]
    public string Name { get; set; }
    public List<string> IngredientAlternatives { get; set; }

}





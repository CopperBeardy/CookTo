using MongoDB.Bson.Serialization.IdGenerators;
using System.Text.Json.Serialization;

namespace CookTo.Server.Documents.UtensilDocument;

public class Utensil : BaseEntity
{
    [BsonElement("utensil_name")]
    public string UtensilName { get; set; }
}

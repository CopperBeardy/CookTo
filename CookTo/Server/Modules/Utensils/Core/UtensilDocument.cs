using CookTo.Server.Modules;

namespace CookTo.Server.Modules.Utensils.Core;

public class UtensilDocument : BaseDocument
{
    [BsonElement("text")]
    public string? Text { get; set; }
}

using CookTo.Server.Modules;

namespace CookTo.Server.Modules.Tips.Core;

public class TipDocument : BaseDocument
{
    [BsonElement("text")]
    public string? Text { get; set; }
}

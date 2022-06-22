using CookTo.Server.Modules;

namespace CookTo.Server.Modules.Categories.Core;

public class CategoryDocument : BaseDocument
{
    [BsonElement("text")]
    public string? Text { get; set; }
}

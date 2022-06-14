using CookTo.Server.Modules;

namespace CookTo.Server.Modules.Cuisines.Core;

public class CuisineDocument : BaseDocument
{
    [BsonElement("text")]
    public string? Text { get; set; }
}


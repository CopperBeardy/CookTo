namespace CookTo.Server.Documents;

public partial class FavoriteRecipeDocument : BaseDocument
{
    [BsonElement("username")]
    public string Username { get; set; }

    [BsonElement("favorites")]
    public List<string>? Favorites { get; set; }
}


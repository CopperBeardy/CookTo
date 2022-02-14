namespace CookTo.Server.Documents.FavoritesDocument;

public partial class FavoriteRecipes : BaseEntity
{
    [BsonElement("username")]
    public string Username { get; set; }

    [BsonElement("favorites")]
    public List<string>? Favorites { get; set; }
}


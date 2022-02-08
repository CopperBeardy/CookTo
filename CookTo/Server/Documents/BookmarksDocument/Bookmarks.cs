﻿namespace CookTo.Server.Documents.BookmarksDocument;

public partial class Bookmarks : BaseEntity
{
    [BsonElement("userId")]
    public string UserId { get; set; }

    [BsonElement("bookMarkedRecipes")]
    public List<SectionBookMarked>? BookMarkedRecipes { get; set; }
}


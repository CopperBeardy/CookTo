﻿namespace CookTo.Server.Documents.RecipeDocument;


public class SectionRecipePart
{
    [BsonElement("part_title")]
    public string PartTitle { get; set; }

    [BsonElement("items")]
    public List<SectionPartIngredient> Items { get; set; }
}
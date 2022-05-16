﻿using CookTo.Server.Documents.IngredientDocument;

namespace CookTo.Server.Documents.RecipeDocument;


public class SectionPartIngredient
{
    [BsonElement("amount")]
    public double Amount { get; set; }

    [BsonElement("ReferenceCode")]
    public string? PartIngredientReferenceCode { get; set; }

    [BsonElement("unit")]
    public MeasureUnit Unit { get; set; }

    [BsonElement("ingredient")]
    public Ingredient Ingredient { get; set; }

    [BsonElement("additional_information")]
    public string? AdditionalInformation { get; set; }
}

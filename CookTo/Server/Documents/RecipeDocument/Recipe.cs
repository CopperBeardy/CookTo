﻿using CookTo.Server.Documents.CategoryDocument;
using CookTo.Server.Documents.CuisineDocument;
using CookTo.Shared.Features.ManageRecipes;

namespace CookTo.Server.Documents.RecipeDocument;

public class Recipe : BaseEntity
{
    [BsonElement("title")]
    public string Title { get; set; }

    [BsonElement("category")]
    public Category Category { get; set; }

    [BsonElement("description")]
    public string Description { get; set; }

    [BsonElement("image")]
    public string? Image { get; set; }

    [BsonElement("prep_time_from")]
    public int PrepTimeFrom { get; set; }

    [BsonElement("prep_time_to")]
    public int PrepTimeTo { get; set; }

    [BsonElement("cooking_time_from")]
    public int CookTimeFrom { get; set; }

    [BsonElement("cooking_time_to")]
    public int CookTimeTo { get; set; }

    [BsonElement("serves")]
    public int Serves { get; set; }

    [BsonElement("cuisine")]
    public Cuisine Cuisine { get; set; }

    [BsonElement("creator")]
    public string? Creator { get; set; }

    [BsonElement("addedBy")]
    public string AddedBy { get; set; }

    [BsonElement("dietaries")]
    public List<Dietary> Dietaries { get; set; }

    [BsonElement("recipe_parts")]
    public List<SectionRecipePart> RecipeParts { get; set; }

    [BsonElement("utensils")]
    public List<SectionUtensilPart> Utensils { get; set; }

    [BsonElement("cooking_steps")]
    public List<SectionCookingStep> CookingSteps { get; set; }

    [BsonElement("shopping_list")]
    public List<string> ShoppingList { get; set; }

    [BsonElement("tips")]
    public List<Tip>? Tips { get; set; }
}


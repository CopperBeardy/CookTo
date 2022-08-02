using CookTo.Server.Modules.Categories.Core;
using CookTo.Server.Modules.Cuisines.Core;
using CookTo.Server.Modules.Recipes.Core;

namespace CookTo.Server.Modules.RecipeHighlighted.Core;

public class HighlightedRecipeDocument : BaseDocument
{
    [BsonElement("title")]
    public string? Title { get; set; }

    [BsonElement("category")]
    public CategoryDocument? Category { get; set; }

    [BsonElement("description")]
    public string? Description { get; set; }

    [BsonElement("image")]
    public string? Image { get; set; }

    [BsonElement("prepTime")]
    public int PrepTime { get; set; }

    [BsonElement("cookTime")]
    public int CookTime { get; set; }

    [BsonElement("cuisine")]
    public CuisineDocument? Cuisine { get; set; }

    [BsonElement("creator")]
    public string? Creator { get; set; }

    [BsonElement("addedBy")]
    public string? AddedBy { get; set; }

    [BsonElement("dietaries")]
    public List<Dietary>? Dietaries { get; set; }

    [BsonElement("shopping_list")]
    public List<string>? ShoppingList { get; set; }

    [BsonElement("tags")]
    public string Tags { get; set; }
}


using CookTo.Server.Modules;
using CookTo.Server.Modules.Categories.Core;
using CookTo.Server.Modules.Cuisines.Core;
using CookTo.Shared.Modules.ManageRecipes;

namespace CookTo.Server.Modules.Recipes.Core;

public class RecipeDocument : BaseDocument
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

    [BsonElement("serves")]
    public string Serves { get; set; }

    [BsonElement("cuisine")]
    public CuisineDocument? Cuisine { get; set; }

    [BsonElement("creator")]
    public string? Creator { get; set; }

    [BsonElement("addedBy")]
    public string? AddedBy { get; set; }

    [BsonElement("dietaries")]
    public List<Dietary>? Dietaries { get; set; }


    [BsonElement("utensils")]
    public List<UtensilPartDocument>? Utensils { get; set; }

    [BsonElement("cooking_steps")]
    public List<CookingStepDocument>? CookingSteps { get; set; }

    [BsonElement("shopping_list")]
    public List<ShoppingItemDocument>? ShoppingList { get; set; }

    [BsonElement("tips")]
    public List<Tip>? Tips { get; set; }

    [BsonElement("tags")]
    public string Tags { get; set; }
}


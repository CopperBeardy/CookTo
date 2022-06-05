
using CookTo.Shared.Features.ManageRecipes;

namespace CookTo.Server.Documents;

public class RecipeDocument : BaseDocument
{
    [BsonElement("title")]
    public string Title { get; set; }

    [BsonElement("category")]
    public CategoryDocument Category { get; set; }

    [BsonElement("description")]
    public string Description { get; set; }

    [BsonElement("image")]
    public string? Image { get; set; }

    [BsonElement("Timings")]
    public TimingsDocument Timings { get; set; }

    [BsonElement("serves")]
    public int Serves { get; set; }

    [BsonElement("cuisine")]
    public CuisineDocument Cuisine { get; set; }

    [BsonElement("creator")]
    public string? Creator { get; set; }

    [BsonElement("addedBy")]
    public string AddedBy { get; set; }

    [BsonElement("dietaries")]
    public List<Dietary> Dietaries { get; set; }

    [BsonElement("utensils")]
    public List<UtensilPartDocument> Utensils { get; set; }

    [BsonElement("cooking_steps")]
    public List<CookingStepDocument> CookingSteps { get; set; }

    [BsonElement("shopping_list")]
    public List<string> ShoppingList { get; set; }

    [BsonElement("tips")]
    public List<Tip>? Tips { get; set; }
}


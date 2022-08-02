using CookTo.Server.Modules;
using CookTo.Server.Modules.Categories.Core;
using CookTo.Server.Modules.Cuisines.Core;
using CookTo.Server.Modules.Recipes.Core;
using CookTo.Shared.Modules.ManageRecipes;

namespace CookTo.Server.Modules.RecipeSummaries.Core;

public class RecipeSummaryDocument : BaseDocument
{
    public RecipeSummaryDocument(string recipeId, string title, CategoryDocument category, CuisineDocument cuisine, string image, string creator, string addedBy, List<Dietary>? dietaries, List<ShoppingItemDocument> shoppingList, string tags)
    {
        RecipeId = recipeId;
        Title = title;
        Category = category;
        Cuisine = cuisine;
        Image = image;
        Creator = creator;
        AddedBy = addedBy;
        Dietaries = dietaries;
        ShoppingList = shoppingList;
        Tags = tags;
    }

    public string RecipeId { get ; set ; }

    [BsonElement("title")]
    public string Title { get; set; }

    [BsonElement("category")]
    public CategoryDocument Category { get; set; }

    [BsonElement("image")]
    public string Image { get; set; }

    [BsonElement("cuisine")]
    public CuisineDocument Cuisine { get; set; }

    [BsonElement("creator")]
    public string Creator { get; set; }

    [BsonElement("addedBy")]
    public string AddedBy { get; set; }

    [BsonElement("dietaries")]
    public List<Dietary> Dietaries { get; set; }

    [BsonElement("shopping_list")]
    public List<ShoppingItemDocument> ShoppingList { get; set; }

    [BsonElement("tags")]
    public string Tags { get; set; }
}


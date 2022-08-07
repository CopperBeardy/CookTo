using CookTo.Server.Modules.Categories.Core;
using CookTo.Server.Modules.Cuisines.Core;
using CookTo.Shared.Modules.ManageRecipes;

namespace CookTo.Server.Modules.Recipes.Core;

public class RecipeDocument : BaseDocument
{
    public string? Title { get; set; }

    public CategoryDocument? Category { get; set; }

    public string? Description { get; set; }

    public string? Image { get; set; }

    public int PrepTime { get; set; }

    public int CookTime { get; set; }

    public string Serves { get; set; }

    public CuisineDocument? Cuisine { get; set; }

    public string? Creator { get; set; }

    public string? AddedBy { get; set; }

    public List<Dietary>? Dietaries { get; set; }

    public List<UtensilPartDocument>? Utensils { get; set; }

    public List<CookingStepDocument>? CookingSteps { get; set; }

    public List<ShoppingItemDocument>? ShoppingItems { get; set; }

    public List<string> ShoppingList { get; set; }

    public List<Tip>? Tips { get; set; }

    public string Tags { get; set; }

    public bool Highlighted { get; set; }
}


using CookTo.Shared.Modules.ManageCategories;
using CookTo.Shared.Modules.ManageCuisines;


namespace CookTo.Shared.Modules.ManageRecipes;

public class HighlightedRecipe
{
    public string Id { get; set; } = string.Empty;

    public Category Category { get; set; } = new Category();

    public string Title { get; set; } = string.Empty;

    public Cuisine Cuisine { get; set; } = new Cuisine();

    public string Image { get; set; } = string.Empty;

    public string Creator { get; set; } = string.Empty;

    public string AddedBy { get; set; } = string.Empty;

    public int PrepTime { get; set; } = 0;

    public int CookTime { get; set; } = 0;

    public string Description { get; set; } = string.Empty;

    public string Tags { get; set; }

    public List<ShoppingItem> ShoppingList { get; set; } = new List<ShoppingItem>();
}

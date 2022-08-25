using CookTo.Shared.Enums;
using CookTo.Shared.Modules.ManageCategories;
using CookTo.Shared.Modules.ManageCuisines;

namespace CookTo.Shared.Modules;

public class HighlightedRecipe
{
    public    string Id { get; set; }

    public Category Category { get; set; } = new Category();

    public   string Title { get; set; } = string.Empty;

    public Cuisine Cuisine { get; set; } = new Cuisine();

    public string Image { get; set; } = string.Empty;

    public   string Creator { get; set; } = string.Empty;

    public   string AddedBy { get; set; } = string.Empty;

    public   int PrepTime { get; set; }

    public   int CookTime { get; set; }

    public   string Description { get; set; } = string.Empty;

    public   List<Dietary>? Dietaries { get; set; }

    public List<string> ShoppingList { get; set; }

    public string Tags { get; set; }
}

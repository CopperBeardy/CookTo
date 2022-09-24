using CookTo.Shared.Enums;
using CookTo.Shared.Models.ManageCategories;
using CookTo.Shared.Models.ManageCuisines;

namespace CookTo.Shared.Models;

public class HighlightedRecipe : BaseEntity
{
    public Category Category { get; set; } = new Category();

    public   string Title { get; set; } = string.Empty;

    public Cuisine Cuisine { get; set; } = new Cuisine();

    public string Image { get; set; } = string.Empty;

    public   string Creator { get; set; } = string.Empty;

    public   string AddedBy { get; set; } = string.Empty;

    public   string PrepTime { get; set; }

    public   string CookTime { get; set; }

    public   string Description { get; set; } = string.Empty;

    public   List<Dietary>? Dietaries { get; set; }

    public List<string> ShoppingList { get; set; }

    public string Tags { get; set; }
}

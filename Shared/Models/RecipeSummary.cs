using CookTo.Shared.Enums;
using CookTo.Shared.Models.ManageCategories;
using CookTo.Shared.Models.ManageCuisines;

namespace CookTo.Shared.Models;

public class RecipeSummary : BaseEntity
{
    public Category Category { get; set; }

    public   string Title { get; set; }

    public Cuisine Cuisine { get; set; }

    public   string Image { get; set; }

    public   string Creator { get; set; }

    public   string AddedBy { get; set; }

    public   List<Dietary>? Dietaries { get; set; }

    public   List<string> ShoppingList { get; set; }

    public   string Tags { get; set; }
}
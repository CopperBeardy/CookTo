using CookTo.Shared.Modules.ManageCategories;
using CookTo.Shared.Modules.ManageCuisines;


namespace CookTo.Shared.Modules.ManageRecipes;

public record RecipeSummary
{
    public string Id { get; set; }

    public Category Category { get; set; }

    public string Title { get; set; }

    public Cuisine Cuisine { get; set; }

    public string Image { get; set; }

    public string Creator { get; set; }

    public string AddedBy { get; set; }

    public string Tags { get; set; }
}

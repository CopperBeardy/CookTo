using CookTo.Shared.Enums;
using CookTo.Shared.Features.ManageCategory;
using CookTo.Shared.Features.ManageCuisine;

namespace CookTo.Shared.Features.ManageRecipes;

public class HighlightedRecipeDto
{
    public string Id { get; set; }

    public CategoryDto Category { get; set; } = new CategoryDto();

    public string Title { get; set; } = string.Empty;

    public CuisineDto Cuisine { get; set; } = new CuisineDto();

    public string Image { get; set; } = string.Empty;

    public string Creator { get; set; } = string.Empty;

    public string AddedBy { get; set; } = string.Empty;

    public int MaxPrepTime { get; set; } = 0;

    public int MaxCookTime { get; set; } = 0;

    public string description { get; set; } = string.Empty;
}

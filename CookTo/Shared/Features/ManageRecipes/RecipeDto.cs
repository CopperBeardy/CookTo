using CookTo.Shared.Enums;
using CookTo.Shared.Features.ManageCategory;
using CookTo.Shared.Features.ManageCuisine;

namespace CookTo.Shared.Features.ManageRecipes;

public class RecipeDto
{
    public string? Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public CuisineDto Cuisine { get; set; } = new CuisineDto();

    public CategoryDto Category { get; set; } = new CategoryDto();

    public string Description { get; set; } = string.Empty;

    public string? Image { get; set; } = string.Empty;

    public int PrepTimeFrom { get; set; }

    public int PrepTimeTo { get; set; }

    public int CookTimeFrom { get; set; }

    public int CookTimeTo { get; set; }

    public int Serves { get; set; }

    public string? Creator { get; set; }

    public string? AddedBy { get; set; }

    public List<Dietary> Dietaries { get; set; } = new List<Dietary>();

    public List<RecipePart> RecipeParts { get; set; } = new List<RecipePart>();

    public List<UtensilPart> Utensils { get; set; } = new List<UtensilPart>();

    public List<CookingStep> CookingSteps { get; set; } = new List<CookingStep>();

    public List<Tip>? Tips { get; set; } = new List<Tip>();

    public List<string>? ShoppingList { get; set; }

    public ImageAction ImageAction { get; set; }
}

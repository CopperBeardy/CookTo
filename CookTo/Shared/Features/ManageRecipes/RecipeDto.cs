using CookTo.Shared.Enums;
using CookTo.Shared.Features.ManageCuisine;

namespace CookTo.Shared.Features.ManageRecipes;

public class RecipeDto
{
    public string? Id { get; set; }

    public string Title { get; set; }

    public CuisineDto Cuisine { get; set; }

    public Category Category { get; set; }

    public string Description { get; set; }

    public string? Image { get; set; }

    public int PrepTimeFrom { get; set; }

    public int PrepTimeTo { get; set; }

    public int CookTimeFrom { get; set; }

    public int CookTimeTo { get; set; }

    public int Serves { get; set; }

    public string AuthorId { get; set; }

    public List<Dietary> Dietaries { get; set; }

    public List<RecipePart> RecipeParts { get; set; } = new List<RecipePart>();

    public List<UtensilPart> Utensils { get; set; } = new List<UtensilPart>();

    public List<CookingStep> CookingSteps { get; set; } = new List<CookingStep>();

    public List<string>? Tips { get; set; }


    public ImageAction ImageAction { get; set; }
}

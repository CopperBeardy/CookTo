using CookTo.Shared.Enums;
using CookTo.Shared.Models;

namespace CookTo.Shared.Features.ManageRecipes;

public class FullRecipe
{
    public string? Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public Cuisine Cuisine { get; set; } = new Cuisine();

    public Category Category { get; set; } = new Category();

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

    public List<Tip>? Tips { get; set; } = new List<Tip>();

    public List<string>? ShoppingList { get; set; }

    public ImageAction ImageAction { get; set; }
}

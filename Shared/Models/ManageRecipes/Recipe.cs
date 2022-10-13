using CookTo.Shared.Enums;
using CookTo.Shared.Models.ManageCategories;
using CookTo.Shared.Models.ManageCuisines;
using CookTo.Shared.Models.ManageIngredients;
using CookTo.Shared.Models.ManageTips;

namespace CookTo.Shared.Models.ManageRecipes;

public sealed class Recipe : BaseEntity
{
    public string Title { get; set; } = string.Empty;

    public Cuisine Cuisine { get; set; } = new Cuisine();

    public Category Category { get; set; } = new Category();

    public string Description { get; set; } = string.Empty;

    public string? Image { get; set; } = string.Empty;

    public string PrepTime { get; set; } = string.Empty;

    public string CookTime { get; set; } = string.Empty;

    public string Serves { get; set; } = string.Empty;

    public string? Creator { get; set; } = string.Empty;

    public string? AddedBy { get; set; } = string.Empty;

    public List<Dietary> Dietaries { get; set; } = new List<Dietary>();

    public List<CookingStep> CookingSteps { get; set; } = new List<CookingStep>();

    public List<UtensilPart> Utensils { get; set; } = new List<UtensilPart>();

    public List<Tip> Tips { get; set; } = new List<Tip>();

    public List<RecipePart> RecipeParts { get; set; } = new List<RecipePart>();

    public List<string>? ShoppingList { get; set; } = new List<string>();

    public string? Tags { get; set; } = string.Empty;

    public bool Highlighted { get; set; } = true;

    public List<Ingredient> ContainedIngredients { get; set; } = new List<Ingredient>();

    public ImageAction ImageAction { get; set; } = ImageAction.None;
}

namespace CookTo.Shared.Features.ManageRecipes;

public class RecipePart
{
    public string PartTitle { get; set; }

    public string? PartCode { get; set; }

    public List<PartIngredient> Items { get; set; } = new List<PartIngredient>();
}


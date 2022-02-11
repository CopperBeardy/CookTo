namespace CookTo.Client.Features.ManageRecipes.ViewModel;


public class RecipePart
{
    public string PartTitle { get; set; }

    public List<PartIngredient> Items { get; set; } = new List<PartIngredient>();
}


using System;
using System.Linq;

namespace CookTo.Shared.Modules.ManageRecipes;

public  class RecipePart
{
    public string Title { get; set; } = string.Empty;

    public List<PartIngredient> PartIngredients { get; set; } = new List<PartIngredient>();
}

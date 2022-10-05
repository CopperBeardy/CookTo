using System;
using System.Linq;

namespace CookTo.Shared.Models.ManageRecipes;

public  class RecipePart
{
    public string Title { get; set; } = string.Empty;

    public List<RecipePartIngredient> RecipePartIngredients { get; set; } = new List<RecipePartIngredient>();
}

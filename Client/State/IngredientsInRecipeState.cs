using CookTo.Shared.Models.ManageIngredients;
using CookTo.Shared.Models.ManageRecipes;

namespace CookTo.Client.State;

public class IngredientsInRecipeState
{
    private List<Ingredient> _ingredients = new List<Ingredient>();
    public List<Ingredient> GetIngredients() => _ingredients;

    public void AddIngredient(Ingredient ingredient) => _ingredients.Add(ingredient);

    public void RemoveIngredient(Ingredient ingredient) => _ingredients.Remove(ingredient);

    public void AddIngredientsOnEditLoad(List<RecipePart> parts)
    {
        if(parts is null)
            return;
        foreach(var part in parts)
        {
            foreach(var partIngredient in part.RecipePartIngredients)
            {
                AddIngredient(partIngredient.Ingredient);
            }
        }
    }
}

using CookTo.Shared.Models.ManageRecipes;

namespace CookTo.Client.State;

public class NewRecipeState
{
    private Recipe _unsavedNewRecipe = new();
    public Recipe GetRecipe() => _unsavedNewRecipe;

    public void SetRecipe(Recipe recipeDto) => _unsavedNewRecipe = recipeDto;

    public void ClearRecipe() => _unsavedNewRecipe = new();
}

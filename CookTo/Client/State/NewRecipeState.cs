using CookTo.Shared.Modules.ManageRecipes;

namespace CookTo.Client.State;

public class NewRecipeState
{
    private FullRecipe _unsavedNewRecipe = new();
    public FullRecipe GetRecipe() => _unsavedNewRecipe;

    public void SetRecipe(FullRecipe recipeDto) => _unsavedNewRecipe = recipeDto;

    public void ClearRecipe() => _unsavedNewRecipe = new();
}

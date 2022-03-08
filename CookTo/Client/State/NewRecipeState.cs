using CookTo.Shared.Features.ManageRecipes;

namespace CookTo.Client.State;

public class NewRecipeState
{
    private RecipeDto _unsavedNewRecipe = new();
    public RecipeDto GetRecipe() => _unsavedNewRecipe;

    public void SetRecipe(RecipeDto recipeDto) => _unsavedNewRecipe = recipeDto;

    public void ClearRecipe() => _unsavedNewRecipe = new();
}

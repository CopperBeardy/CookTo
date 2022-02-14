using Blazored.LocalStorage;

namespace CookTo.Client.State;

public class AppState
{
    private bool _isInitialized;


    public NewRecipeState NewRecipeState { get; }

    public FavoriteRecipesState FavoriteRecipesState { get; }

    public AppState(ILocalStorageService localStorageService)
    {
        NewRecipeState = new NewRecipeState();
        FavoriteRecipesState = new FavoriteRecipesState(localStorageService);
    }

    public async Task Initialize()
    {
        if(!_isInitialized)
        {
            await FavoriteRecipesState.Initialize();
            _isInitialized = true;
        }
    }
}

using Blazored.LocalStorage;

namespace CookTo.Client.State;

public class AppState
{
    private bool _isInitialized;

    public NewRecipeState NewRecipeState { get; }

    public AppState(ILocalStorageService localStorageService)
    { NewRecipeState = new NewRecipeState(); }

    public Task Initialize()
    {
        if (!_isInitialized)
        {
            _isInitialized = true;
        }

        return Task.CompletedTask;
    }
}

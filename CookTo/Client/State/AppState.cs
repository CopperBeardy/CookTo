using Blazored.LocalStorage;
using CookTo.Client.Managers.Interfaces;

namespace CookTo.Client.State;

public class AppState
{
    private bool _isInitialized;

    public NewRecipeState NewRecipeState { get; }


    public AppState(ILocalStorageService localStorageService, IFavoritesManager favoritesManager)
    { NewRecipeState = new NewRecipeState(); }

    public async Task Initialize()
    {
        if(!_isInitialized)
        {
            _isInitialized = true;
        }
    }
}

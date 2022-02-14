using Blazored.LocalStorage;
using CookTo.Shared.Features.ManageRecipes;
using System.Diagnostics;

namespace CookTo.Client.State;

public class FavoriteRecipesState
{
    private const string FavouriteRecipesKey = "favoriteRecipes";

    private bool _isInitialized;
    private List<RecipeDto> _favoriteRecipes = new();
    private readonly ILocalStorageService _localStorageService;

    public IReadOnlyList<RecipeDto> FavoriteRecipes => _favoriteRecipes.AsReadOnly();

    public event Action? OnChange;

    public FavoriteRecipesState(ILocalStorageService localStorageService)
    { _localStorageService = localStorageService; }

    public async Task Initialize()
    {
        if(!_isInitialized)
        {
            _favoriteRecipes = await _localStorageService.GetItemAsync<List<RecipeDto>>(FavouriteRecipesKey) ??
                new List<RecipeDto>();
            _isInitialized = true;
            NotifyStateHasChanged();
        }
    }

    public async Task AddFavorite(RecipeDto recipe)
    {
        if(_favoriteRecipes.Any(_ => _.Id == recipe.Id))
            return;

        _favoriteRecipes.Add(recipe);

        await _localStorageService.SetItemAsync(FavouriteRecipesKey, _favoriteRecipes);

        NotifyStateHasChanged();
    }

    public async Task RemoveFavorite(RecipeDto recipe)
    {
        var existingRecipe = _favoriteRecipes.SingleOrDefault(_ => _.Id == recipe.Id);

        if(existingRecipe is null)
            return;

        _favoriteRecipes.Remove(existingRecipe);

        await _localStorageService.SetItemAsync(FavouriteRecipesKey, _favoriteRecipes);

        NotifyStateHasChanged();
    }

    public bool IsFavorite(RecipeDto recipe) => _favoriteRecipes.Any(_ => _.Id == recipe.Id);

    private void NotifyStateHasChanged() => OnChange?.Invoke();
}
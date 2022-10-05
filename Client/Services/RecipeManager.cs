using CookTo.Shared;
using CookTo.Shared.Models.ManageRecipes;

namespace CookTo.Client.Services;

public class RecipeManager : APIRepository<Recipe>
{
    public RecipeManager(IHttpClientFactory httpClientFactory) : base(httpClientFactory, ControllerNames.RECIPE, "Id")
    {
    }
}

using CookTo.Shared;
using CookTo.Shared.Models.ManageIngredients;

namespace CookTo.Client.Services;

public class IngredientManager : APIRepository<Ingredient>
{
    public IngredientManager(IHttpClientFactory httpClientFactory) : base(httpClientFactory, ControllerNames.INGREDIENT, "Id")
    {
    }
}

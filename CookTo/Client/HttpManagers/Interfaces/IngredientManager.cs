using CookTo.Shared.Modules.ManageIngredients;

namespace CookTo.Client.HTTPManagers.Interfaces;

public class IngredientManager : BaseManager<Ingredient>
{
    public IngredientManager(IHttpClientFactory factory) : base(factory, "ingredient")
    {
    }
}


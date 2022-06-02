using CookTo.Shared.Features;
using CookTo.Shared.Models;

namespace CookTo.Client.Managers;

public class IngredientManager : BaseManager<Ingredient>
{
    public IngredientManager(IHttpClientFactory factory) : base(factory, "ingredient")
    {
    }
}


using CookTo.Shared.Features.ManageIngredients;

namespace CookTo.Client.Managers;

public class IngredientManager : BaseManager<IngredientDto>
{
    public IngredientManager(IHttpClientFactory factory) : base(factory, "ingredient")
    {
    }
}


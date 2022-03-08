using CookTo.Shared.Features.ManageRecipes;

namespace CookTo.Client.Managers;

public class RecipeManager : BaseManager<RecipeDto>
{
    public RecipeManager(IHttpClientFactory factory) : base(factory, "recipe")
    {
    }
}

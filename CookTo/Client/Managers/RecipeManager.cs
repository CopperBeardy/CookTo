using CookTo.Shared.Features.ManageRecipes;

namespace CookTo.Client.Managers;

public class RecipeManager : BaseManager<FullRecipe>
{
    public RecipeManager(IHttpClientFactory factory) : base(factory, "recipe")
    {
    }
}

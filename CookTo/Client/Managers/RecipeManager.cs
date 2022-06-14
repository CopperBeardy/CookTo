using CookTo.Shared.Modules.ManageRecipes;

namespace CookTo.Client.Managers;

public class RecipeManager : BaseManager<FullRecipe>
{
    public RecipeManager(IHttpClientFactory factory) : base(factory, "recipe")
    {
    }
}

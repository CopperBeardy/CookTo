
using CookTo.Shared.Modules.ManageRecipes;


namespace CookTo.Client.HttpManagers;

public class RecipeManager : BaseManager<FullRecipe>
{
    public RecipeManager(IHttpClientFactory factory) : base(factory, "recipe")
    {
    }
}

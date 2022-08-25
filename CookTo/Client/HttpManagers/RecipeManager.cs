
using CookTo.Shared;
using CookTo.Shared.Modules.ManageRecipes;


namespace CookTo.Client.HTTPManagers;

public class RecipeManager : BaseManager<Recipe>
{
    public RecipeManager(IHttpClientFactory factory) : base(factory, EndpointTemplate.RECIPE)
    {
    }
}

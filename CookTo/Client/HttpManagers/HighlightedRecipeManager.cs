using CookTo.Shared;
using CookTo.Shared.Modules;


namespace CookTo.Client.HTTPManagers;

public class HighlightedRecipeManager : BaseManager<HighlightedRecipe>
{
    public HighlightedRecipeManager(IHttpClientFactory factory) : base(factory, EndpointTemplate.HIGHLIGHTED)
    {
    }
}

using CookTo.Shared.Modules.ManageRecipes;
using Newtonsoft.Json;

namespace CookTo.Client.HttpManagers;

public class HighlightedRecipeManager : BaseManager<HighlightedRecipe>
{
    public HighlightedRecipeManager(IHttpClientFactory factory) : base(factory, "highlighted")
    {
    }
}

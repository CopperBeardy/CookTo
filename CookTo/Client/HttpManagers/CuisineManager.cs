using CookTo.Shared.Modules.ManageCuisines;

namespace CookTo.Client.HttpManagers;

public class CuisineManager : BaseManager<Cuisine>
{
    public CuisineManager(IHttpClientFactory factory) : base(factory, "cuisine")
    {
    }
}


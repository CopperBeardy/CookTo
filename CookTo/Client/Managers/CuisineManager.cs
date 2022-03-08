using CookTo.Shared.Features.ManageCuisine;

namespace CookTo.Client.Managers;

public class CuisineManager : BaseManager<CuisineDto>
{
    public CuisineManager(IHttpClientFactory factory) : base(factory, "cuisine")
    {
    }
}


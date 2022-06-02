using CookTo.Shared.Features;
using CookTo.Shared.Models;

namespace CookTo.Client.Managers;

public class CuisineManager : BaseManager<Cuisine>
{
    public CuisineManager(IHttpClientFactory factory) : base(factory, "cuisine")
    {
    }
}


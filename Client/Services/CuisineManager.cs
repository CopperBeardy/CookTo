using CookTo.Shared;
using CookTo.Shared.Models.ManageCuisines;

namespace CookTo.Client.Services;

public class CuisineManager : APIRepository<Cuisine>
{
    public CuisineManager(IHttpClientFactory httpClientFactory) : base(httpClientFactory, ControllerNames.CUISINE, "Id")
    {
    }
}

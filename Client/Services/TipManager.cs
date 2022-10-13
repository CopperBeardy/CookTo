using CookTo.Shared;
using CookTo.Shared.Models.ManageTips;

namespace CookTo.Client.Services;

public class TipManager : APIRepository<Tip>
{
    public TipManager(IHttpClientFactory httpClientFactory) : base(httpClientFactory, ControllerNames.TIP)
    {
    }
}

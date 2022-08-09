
using CookTo.Shared;
using CookTo.Shared.Modules.ManageUtensils;

namespace CookTo.Client.HTTPManagers;

public class UtensilManager : BaseManager<Utensil>
{
    public UtensilManager(IHttpClientFactory factory) : base(factory, EndpointTemplate.UTENSIL)
    {
    }
}

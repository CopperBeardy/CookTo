
using CookTo.Shared.Modules.ManageUtensils;

namespace CookTo.Client.HttpManagers;

public class UtensilManager : BaseManager<Utensil>
{
    public UtensilManager(IHttpClientFactory factory) : base(factory, "utensil")
    {
    }
}

using CookTo.Shared.Features;
using CookTo.Shared.Models;

namespace CookTo.Client.Managers;

public class UtensilManager : BaseManager<Utensil>
{
    public UtensilManager(IHttpClientFactory factory) : base(factory, "utensil")
    {
    }
}

using CookTo.Shared.Features.ManageUtensils;

namespace CookTo.Client.Managers;

public class UtensilManager : BaseManager<UtensilDto>
{
    public UtensilManager(IHttpClientFactory factory) : base(factory, "utensil")
    {
    }
}

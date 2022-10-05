using CookTo.Shared;
using CookTo.Shared.Models.ManageUtensils;

namespace CookTo.Client.Services;

public class UtensilManager : APIRepository<Utensil>
{
    public UtensilManager(IHttpClientFactory httpClientFactory) : base(httpClientFactory, ControllerNames.UTENSIL, "Id")
    {
    }
}

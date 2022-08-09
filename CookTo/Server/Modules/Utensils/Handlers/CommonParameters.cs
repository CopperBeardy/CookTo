using CookTo.Server.Modules.Categories.Services;
using CookTo.Server.Modules.Cuisines.Services;
using CookTo.Server.Modules.Utensils.Services;

namespace CookTo.Server.Modules.Utensils.Handlers;


public record CommonParameters
{
    public IUtensilService UtensilService { get; set; }

    public CancellationToken CancellationToken { get; set; }
}


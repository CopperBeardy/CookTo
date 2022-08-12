using CookTo.Server.Modules.Utensils.Services;

namespace CookTo.Server.Modules.Utensils.Handlers;


public record CommonParameters
{
    public IUtensilService UtensilService { get; set; }

    public CancellationToken CancellationToken { get; set; }
}


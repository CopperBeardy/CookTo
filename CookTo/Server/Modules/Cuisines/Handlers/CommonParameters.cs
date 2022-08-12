using CookTo.Server.Modules.Cuisines.Services;

namespace CookTo.Server.Modules.Cuisines.Handlers;


public record CommonParameters
{
    public ICuisineService CuisineService { get; set; }

    public CancellationToken CancellationToken { get; set; }
}


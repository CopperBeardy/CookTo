using CookTo.Server.Modules.Tips.Services;

namespace CookTo.Server.Modules.Tips.Handlers;


public record CommonParameters
{
    public ITipService TipService { get; set; }

    public CancellationToken CancellationToken { get; set; }
}


using CookTo.Server.Modules.Categories.Services;

namespace CookTo.Server.Modules.Categories.Handlers;


public record CommonParameters
{
    public ICategoryService CategoryService { get; set; }

    public CancellationToken CancellationToken { get; set; }
}


using CookTo.Server.Modules.Recipes.Handlers;
using CookTo.Shared;

namespace CookTo.Server.Modules.Recipes;

public class RecipeSummaryModule : IModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var api = endpoints.MapGroup(EndpointTemplate.SUMMARY);
        endpoints.MapGet("/{amount}", async (int amount, [AsParameters] CommonParameters cp) => await GetSummariesHandler.Handle(amount, cp));
        return api;
    }

    public IServiceCollection RegisterModule(IServiceCollection services) => services;
}

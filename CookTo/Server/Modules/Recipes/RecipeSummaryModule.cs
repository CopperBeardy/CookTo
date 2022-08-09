using CookTo.Server.Modules.Recipes.Handlers;
using CookTo.Server.Modules.Recipes.Services;
using CookTo.Shared;
using CookTo.Shared.Modules;
using CookTo.Shared.Modules.ManageCategories;
using CookTo.Shared.Modules.ManageCuisines;

namespace CookTo.Server.Modules.Recipes;

public class RecipeSummaryModule : IModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var api = endpoints.MapGroup(EndpointTemplate.SUMMARY);
        endpoints.MapGet("/{amount}", async (int amount, [AsParameters]CommonParameters cp) => await GetSummariesHandler.Handle(amount, cp));
        return api;
    }

    public IServiceCollection RegisterModule(IServiceCollection services) => services;
}

using CookTo.Server.Modules.Recipes.Handlers;
using CookTo.Server.Modules.Recipes.Services;
using CookTo.Shared;
using CookTo.Shared.Modules;
using CookTo.Shared.Modules.ManageCategories;
using CookTo.Shared.Modules.ManageCuisines;

namespace CookTo.Server.Modules.Recipes;

public class RecipeHighlightedModule : IModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var api = endpoints.MapGroup(EndpointTemplate.HIGHLIGHTED);

        api.MapGet( "/", async ([AsParameters]CommonParameters cp) => await GetHighlightedRecipeHandler.Handle(cp));

        return api;
    }

    public IServiceCollection RegisterModule(IServiceCollection services) => services;
}

using CookTo.Server.Modules.Recipes.Handlers;
using CookTo.Shared;

namespace CookTo.Server.Modules.Recipes;

public class RecipeHighlightedModule : IModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var api = endpoints.MapGroup(EndpointTemplate.HIGHLIGHTED);

        api.MapGet("/", async ([AsParameters] CommonParameters cp) => await GetHighlightedRecipeHandler.Handle(cp));

        return api;
    }

    public IServiceCollection RegisterModule(IServiceCollection services) => services;
}

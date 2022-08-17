using CookTo.DataAccess.Documents.RecipeDocumentAccess.Services;
using CookTo.Server.Modules.Recipes.Handlers;
using CookTo.Shared;

namespace CookTo.Server.Modules.Recipes;

public class RecipeHighlightedModule : IModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var api = endpoints.MapGroup(EndpointTemplate.HIGHLIGHTED);

        api.MapGet("/", async (IRecipeService service, CancellationToken cancellationToken) => await GetHighlightedRecipe.Handle(service, cancellationToken));

        return api;
    }

    public IServiceCollection RegisterModule(IServiceCollection services) => services;
}

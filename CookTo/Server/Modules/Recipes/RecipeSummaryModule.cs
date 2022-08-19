using CookTo.DataAccess.Documents.RecipeDocumentAccess.Services;
using CookTo.Server.Modules.Recipes.Handlers;
using CookTo.Shared;

namespace CookTo.Server.Modules.Recipes;

public class RecipeSummaryModule : IModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var api = endpoints.MapGroup(EndpointTemplate.SUMMARY);
        endpoints.MapGet("/{amount}", async (int amount, IRecipeService service, CancellationToken cancellationToken) =>
        {
            var response = await GetSummaries.Handle(amount, service, cancellationToken);
            return Results.Ok(response);
        });
        return api;
    }

    public IServiceCollection RegisterModule(IServiceCollection services) => services;
}

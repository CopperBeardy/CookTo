using CookTo.DataAccess.Documents.IngredientDocumentAccess.Services;
using CookTo.Server.Modules.Ingredients.Handlers;
using CookTo.Shared;
using CookTo.Shared.Modules.ManageIngredients;
using System.Reflection.Metadata;

namespace CookTo.Server.Modules.Ingredients;

public class IngredientModule : IModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var api = endpoints.MapGroup(EndpointTemplate.INGREDIENT);
        api.MapGet("/", async (IIngredientService service, CancellationToken cancellationToken) => await GetAll.Handle(service, cancellationToken));
        api.MapPost("/", async (Ingredient ingredient, IIngredientService service, CancellationToken cancellationToken) => await Post.Handle(ingredient, service, cancellationToken))
            .RequireAuthorization();
        return api;
    }

    public IServiceCollection RegisterModule(IServiceCollection services)
    {
        services.AddScoped<IIngredientService, IngredientService>();
        return services;
    }
}

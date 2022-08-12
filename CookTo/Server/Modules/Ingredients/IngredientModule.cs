using CookTo.Server.Modules.Ingredients.Core;
using CookTo.Server.Modules.Ingredients.Handlers;
using CookTo.Server.Modules.Ingredients.Services;
using CookTo.Shared;
using CookTo.Shared.Modules.ManageIngredients;

namespace CookTo.Server.Modules.Ingredients;

public class IngredientModule : IModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var api = endpoints.MapGroup(EndpointTemplate.INGREDIENT);
        api.MapGet( "/", async ([AsParameters]CommonParameters cp) => await GetAllHandler.Handle(cp));
        api.MapPost( "/", async (Ingredient ingredient, [AsParameters]CommonParameters cp) => await PostHandler.Handle(ingredient, cp))
            .RequireAuthorization();
        return api;
    }

    public IServiceCollection RegisterModule(IServiceCollection services)
    {
        services.AddScoped<IIngredientService, IngredientService>();
        return services;
    }
}
